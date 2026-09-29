using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Models;
using TaskFlowBackend.Repositories.UserRepository;
using TaskFlowBackend.Services;

namespace TaskFlowBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly AuthService _authService;

    public AuthController(IUserRepository userRepository, AuthService authService)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = await _authService.RegisterAsync(request);
        if (user == null)
        {
            return BadRequest("Username already exists.");
        }

        return Ok(new { user.Id, user.Username });
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        if (response == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        return Ok(response);
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
    {
        var response = await _authService.RefreshTokenAsync(request.RefreshToken);
        if (response == null)
        {
            return Unauthorized("Invalid or expired refresh token.");
        }

        return Ok(response);
    }
    
    [HttpGet("protected")]
    [Authorize]
    public IActionResult Protected()
    {
        var username = User.Identity?.Name;
        return Ok($"Hello, {username}! This is a protected endpoint.");
    }
    
    [HttpPost("revoke")]
    public async Task<IActionResult> Revoke([FromBody] RefreshTokenRequest request)
    {
        var success = await _authService.RevokeRefreshTokenAsync(request.RefreshToken);
        if (!success)
        {
            return BadRequest("Invalid or already revoked refresh token.");
        }

        return Ok("Refresh token revoked.");
    }
    
}