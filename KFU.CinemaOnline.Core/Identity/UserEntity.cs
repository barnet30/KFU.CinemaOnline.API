using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KFU.CinemaOnline.Core.Identity
{
    public class UserEntity : BaseEntity
    {
        [Required] public string Username { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
