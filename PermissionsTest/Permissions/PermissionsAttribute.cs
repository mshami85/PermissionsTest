using Microsoft.AspNetCore.Authorization;

namespace APIs.Permissions
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        public Permission Permission
        {
            get => Enum.Parse<Permission>(Policy![PermissionConstants.PolicyPrefix.Length..]);
            set => Policy = $"{PermissionConstants.PolicyPrefix}{value}";
        }

        public PermissionAttribute(Permission permission)
        {
            Permission = permission;
        }
    }
}