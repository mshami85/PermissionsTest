using Microsoft.AspNetCore.Authorization;

namespace PermissionsTest.AuthPermissions;

internal class PermissionAttribute : AuthorizeAttribute
{
    public Permission Permission
    {
        get => Enum.Parse<Permission>(Policy[Constants.PolicyPrefix.Length..]);
        set => Policy = $"{Constants.PolicyPrefix}{value}";
    }

    public PermissionAttribute(Permission permission)
    {
        Permission = permission;
    }
}