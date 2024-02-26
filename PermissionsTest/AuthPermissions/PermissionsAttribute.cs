using Microsoft.AspNetCore.Authorization;

namespace PermissionsTest.AuthPermissions;

internal class PermissionAttribute : AuthorizeAttribute
{
    public Permission Permission
    {
        get => Enum.Parse<Permission>(Policy[Policy.IndexOf(".")..]);
        set => Policy = $"POLICY.{value}";
    }

    public PermissionAttribute(Permission permission)
    {
        Permission = permission;
    }
}