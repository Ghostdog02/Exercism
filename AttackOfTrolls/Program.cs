using System;

namespace AttackOfTrolls
{
    [Flags]
    enum AccountType
    {
        Guest = 1,
        User = 2,
        Moderator = 4
    }

    [Flags]
    enum Permission
    {
        Read = 1,
        Write = 2,
        Delete = 4,
        All = Read | Write | Delete,
        None = 0
    }

    static class Permissions
    {
        public static Permission Default(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Guest:
                    return Permission.Read;
                case AccountType.User:
                    return Permission.Read | Permission.Write;
                case AccountType.Moderator:
                    return Permission.All;
                default:
                    return Permission.None;
            }
        }

        public static Permission Grant(Permission current, Permission grant)
        {
            return current | grant;
        }

        public static Permission Revoke(Permission current, Permission revoke)
        {
            var permission = current & ~revoke;
            return permission;
        }

        public static bool Check(Permission current, Permission check)
        {
            return current.HasFlag(check);
        }

        static void Main()
        {
            var test = Permissions.Check(Permission.None, Permission.Read).ToString();
            Console.WriteLine(test);

        }
    }


}
