using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AuthenticationSystem
{
    public class Authenticator
    {
        private class EyeColor
        {
            public const string Blue = "blue";
            public const string Green = "green";
            public const string Brown = "brown";
            public const string Hazel = "hazel";
            public const string Brey = "grey";
        }

        public Authenticator(Identity admin)
        {
            this.admin = new(admin.Email, admin.EyeColor);
        }

        private Identity admin;

        private IReadOnlyDictionary<string, Identity> developers
            = new ReadOnlyDictionary<string, Identity>(new Dictionary<string, Identity>
            {
                ["Bertrand"] = new Identity
                {
                    Email = "bert@ex.ism",
                    EyeColor = "blue"
                },

                ["Anders"] = new Identity
                {
                    Email = "anders@ex.ism",
                    EyeColor = "brown"
                }
            });

        public Identity Admin
        {

            get { return admin; }
            private set { admin = value; }
        }

        public IReadOnlyDictionary<string, Identity> GetDevelopers()
        {
            return developers;
        }
    }

    public readonly struct Identity
    {
        public Identity(string email, string eyeColor)
        {
            Email = email;
            EyeColor = eyeColor;
        }

        public string Email { get; init; }

        public string EyeColor { get; init; }
    }

    public class Program 
    {
        static void Main()
        {

        }
    }
}
