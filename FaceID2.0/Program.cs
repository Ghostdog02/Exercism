using System;
using System.Collections.Generic;
using Xunit;

namespace FaceID2._0
{
    public class FacialFeatures
    {
        public string EyeColor { get; }
        public decimal PhiltrumWidth { get; }

        public FacialFeatures(string eyeColor, decimal philtrumWidth)
        {
            EyeColor = eyeColor;
            PhiltrumWidth = philtrumWidth;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var second = obj as FacialFeatures;
            return EyeColor == second.EyeColor && PhiltrumWidth == second.PhiltrumWidth;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return EyeColor.GetHashCode() ^ PhiltrumWidth.GetHashCode();

        }

    }

    public class Identity
    {
        public string Email { get; }
        public FacialFeatures FacialFeatures { get; }

        public Identity(string email, FacialFeatures facialFeatures)
        {
            Email = email;
            FacialFeatures = facialFeatures;
        }

        public override bool Equals(object obj)
        {
            var second = obj as Identity;
            return Email == second.Email && FacialFeatures.Equals(second.FacialFeatures);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Email.GetHashCode() ^ FacialFeatures.GetHashCode();
        }
    }

    public class Authenticator
    {
        private readonly static Identity Admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

        HashSet<Identity> identities = new HashSet<Identity>();

        public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);
        
        public bool IsAdmin(Identity identity) => identity.Equals(Admin);
       
        public bool Register(Identity identity)
        {

            if (identities.Contains(identity))
            {
                return false;
            }

            else
            {
                identities.Add(identity);
                return true;
            }
        }

        public bool IsRegistered(Identity identity) => identities.Contains(identity);
        
        public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;

        public static void Main()
        {
            var authenticator = new Authenticator();
            authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)));
            authenticator.IsRegistered(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        }
    }
}
