namespace EVNETest.Auth
{
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    public class AuthOptions
    {
        private const string SecretKey = "evne-test-secret--key";
        public const string Issuer = "EVNETestApi";
        public const string Audience = "EVNETestClient";
        public const int Lifetime = 9999;
        public static SymmetricSecurityKey Key
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
            }
        }
    }
}