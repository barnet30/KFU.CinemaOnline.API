using System.ComponentModel.DataAnnotations;

namespace KFU.CinemaOnline.Core.Identity
{
    public class AuthenticateRequestModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}
