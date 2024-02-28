using Microsoft.AspNetCore.Authorization;
using PermissionsTest.Classes;

namespace PermissionsTest.AuthPermissions;

class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var perm = requirement.Permission;
        var community = context.User.Claims.FirstOrDefault(c => c.Type == Constants.CurrentCommunityClaim);
        var userPermissions = context.User.Claims.FirstOrDefault(c => c.Type.StartsWith(Constants.PermissionClaimPrefix + community?.Value));
        if (userPermissions != null)
        {
            var vector = userPermissions.Value;
            if (vector?.HasPermission(perm) ?? false)
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}