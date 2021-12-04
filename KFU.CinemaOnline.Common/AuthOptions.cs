using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KFU.CinemaOnline.Common
{
    public class AuthOptions
    {
        /// <summary>
        /// Who generated token
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Generated token for
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Secret key
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Lifetime token (sec)
        /// </summary>
        public int TokenLifetime { get; set; }

        /// <summary>
        /// Method for generate key from secret
        /// </summary>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
