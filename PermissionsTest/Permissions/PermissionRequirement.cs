using Microsoft.AspNetCore.Authorization;

namespace APIs.Permissions
{
    class PermissionRequirement : IAuthorizationRequirement
    {
        public Permission Permission { get; private set; }

        public PermissionRequirement(Permission permission)
        {
            Permission = permission;
        }
    }
}