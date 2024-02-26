using Microsoft.AspNetCore.Authorization;

namespace PermissionsTest.AuthPermissions;

class PermissionRequirement : IAuthorizationRequirement
{
    public Permission Permission { get; private set; }

    public PermissionRequirement(Permission permission)
    {
        Permission = permission;
    }
}