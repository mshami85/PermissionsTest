using APIs.Classes;
using Microsoft.AspNetCore.Authorization;

namespace APIs.Permissions
{
    class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var perm = requirement.Permission;
            var community = context.User.GetCurrentCommunityId();
            if (community > 0)
            {
                var userPermissions = context.User.GetPermissions(community);
                if (userPermissions != null && userPermissions.Any(p => p == perm))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}