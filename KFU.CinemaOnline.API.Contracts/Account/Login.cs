using System.ComponentModel.DataAnnotations;

namespace KFU.CinemaOnline.API.Contracts.Account
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
