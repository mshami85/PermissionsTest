using PermissionsTest.AuthPermissions;

namespace PermissionsTest.Classes;

public static class EnumExt
{
    public static IEnumerable<Permission> EnumToString(this string claim)
    {
        for (var i = 0; i < claim.Length; i++)
        {
            if (Enum.IsDefined(typeof(Permission), i) && claim[i] == '1')
            {
                yield return (Permission)i;
            }
        }
    }
}
