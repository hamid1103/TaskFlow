using System.Security.Claims;

namespace TaskFlowBackend.Extensions;

public static class ClaimsPrincipalExtensions
{
    //Only valid on endpoints with [Authorize], otherwise there is no user id claim
    public static int GetUserId(this ClaimsPrincipal user)
    {
        string? userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userId, out int id))
        {
            throw new InvalidOperationException("No valid user id claim found.");
        }
        return id;
    }
}
