using APIs.Permissions;
using System.Security.Claims;

namespace APIs.Classes
{
    public static class ClaimsPrincipalExt
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public static string? GetUserName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }

        public static IEnumerable<string> GetRoles(this ClaimsPrincipal user)
        {
            return user?.Claims?.Where(c => c.Type == ClaimTypes.Role)
                                .Select(c => c.Value) ?? Enumerable.Empty<string>();
        }

        public static int GetCurrentCommunityId(this ClaimsPrincipal user)
        {
            try
            {
                return Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == PermissionConstants.CurrentCommunityClaim)?.Value);
            }
            catch
            {
                return 0;
            }
        }

        public static IEnumerable<Permission> GetPermissions(this ClaimsPrincipal user, int? community_id)
        {
            community_id ??= user.GetCurrentCommunityId();
            return user.Claims.FirstOrDefault(c => c.Type == PermissionConstants.PermissionClaimPrefix + community_id)?.Value
                              .ResolvePermissions() ?? Enumerable.Empty<Permission>();
        }
    }
}
