using System.ComponentModel.DataAnnotations;

namespace KFU.CinemaOnline.API.Contracts.Account
{
    public class RegisterRequest
    {
        [Required] 
        public string Username { get; set; }
        
        [Required] 
        [EmailAddress] 
        public string Email { get; set; }
        
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}