using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Services;

public class AuthService
{
    private readonly TaskContext _context;
    private readonly IConfiguration _configuration;
    public AuthService(TaskContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<User?> RegisterAsync(RegisterRequest registerRequest)
    {
        if (_context.Users.Any(u => u.Username == registerRequest.Username)) return null;

        User newUser = new User
        {
            Username = registerRequest.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return newUser;
    }
    
    public async Task<TokenResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null ||
            !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return null; // Invalid credentials
        }

        var accessToken = GenerateAccessToken(user);
        var refreshToken = await GenerateRefreshTokenAsync(user, request);

        return new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }
    
    private string GenerateAccessToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(_configuration["Key"]);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["AccessTokenExpirationMinutes"]!)),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<RefreshToken> GenerateRefreshTokenAsync(User user)
    {
        var refreshToken = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            UserId = user.Id,
            Expires = DateTime.UtcNow.AddDays(
                double.Parse(_configuration["Jwt:RefreshTokenExpirationDays"]!)),
        };
        
        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();
        return refreshToken;
    }
    
    private async Task<RefreshToken> GenerateRefreshTokenAsync(User user, LoginRequest loginRequest)
    {
        var refreshToken = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            UserId = user.Id,
            Expires = DateTime.UtcNow.AddDays(
                double.Parse(_configuration["Jwt:RefreshTokenExpirationDays"]!)),
        };

        if (loginRequest is { RememberMe: true, Descriptor: not null })
        {
            refreshToken.Descriptor = loginRequest.Descriptor;
        }
        
        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();
        return refreshToken;
    }
    
    public async Task<TokenResponse?> RefreshTokenAsync(string refreshToken)
    {
        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(t => t.Token == refreshToken);

        if (token == null || token.Revoked || token.Expires < DateTime.UtcNow)
        {
            return null; // Invalid or expired token
        }

        var user = await _context.Users.FindAsync(token.UserId);
        if (user == null)
        {
            return null; // User not found
        }

        // Generate new access token
        var newAccessToken = GenerateAccessToken(user);

        // Generate new refresh token and revoke the old one
        token.Revoked = true;
        var newRefreshToken = await GenerateRefreshTokenAsync(user);
        if (token.Descriptor != null)
        {
            newRefreshToken.Descriptor = token.Descriptor;
        }
        await _context.SaveChangesAsync();

        return new TokenResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken.Token
        };
    }

    public async Task<bool> RevokeRefreshTokenAsync(string refreshToken)
    {
        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(t => t.Token == refreshToken);

        if (token == null || token.Revoked)
        {
            return false;
        }

        token.Revoked = true;
        await _context.SaveChangesAsync();
        return true;
    }
    
}