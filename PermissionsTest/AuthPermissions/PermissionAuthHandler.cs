using Microsoft.AspNetCore.Authorization;

namespace PermissionsTest.AuthPermissions;

class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly ILogger<PermissionAuthorizationHandler> _logger;

    public PermissionAuthorizationHandler(ILogger<PermissionAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var perm = requirement.Permission;
        var community = context.User.Claims.FirstOrDefault(c => c.Type == "Community");

        var userPermissions = context.User.Claims.FirstOrDefault(c => c.Type.StartsWith("PermissionFor" + community?.Value, StringComparison.OrdinalIgnoreCase));
        if (userPermissions != null)
        {
            var vector = userPermissions.Value;
            if (vector[(int)perm] == '1')
            {
                context.Succeed(requirement);
            }
        }
        else
        {
            _logger.LogInformation("No DateOfBirth claim present");
        }

        return Task.CompletedTask;
    }
}