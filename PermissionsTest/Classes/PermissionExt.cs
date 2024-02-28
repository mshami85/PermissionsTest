using PermissionsTest.AuthPermissions;
using System.Text;

namespace PermissionsTest.Classes;

public static class PermissionExt
{
    public static IEnumerable<Permission> ResolvePermissions(this string claim)
    {
        for (var i = 0; i < claim.Length; i++)
        {
            if (Enum.IsDefined(typeof(Permission), i) && claim[i] == '1')
            {
                yield return (Permission)i;
            }
        }
    }

    public static string CreatePermissionsVector(bool granted = false)
    {
        var count = Enum.GetValues<Permission>().Length;
        return new string(Enumerable.Repeat(granted ? '1' : '0', count).ToArray());
    }

    public static string GrantPermission(this string claim, Permission permission)
    {
        var builder = new StringBuilder(claim);
        builder[(int)permission] = '1';
        return builder.ToString();
    }

    public static string RevokePermission(this string claim, Permission permission)
    {
        var builder = new StringBuilder(claim);
        builder[(int)permission] = '0';
        return builder.ToString();
    }

    public static bool HasPermission(this string claim, Permission permission)
    {
        return claim[(int)permission] == '1';
    }
}
