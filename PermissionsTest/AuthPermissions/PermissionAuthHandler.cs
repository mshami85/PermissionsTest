using Microsoft.AspNetCore.Authorization;

namespace PermissionsTest.AuthPermissions;

class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
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
        
        return Task.CompletedTask;
    }
}