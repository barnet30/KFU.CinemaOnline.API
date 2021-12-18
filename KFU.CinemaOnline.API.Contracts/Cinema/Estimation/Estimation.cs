using System.ComponentModel.DataAnnotations;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Estimation
{
    public class Estimation
    {
        [Required] 
        public int UserId { get; set; }
        
        [Required] 
        public int MovieId { get; set; }
        
        [Required] 
        [Range(typeof(int), "0", "10")] 
        public int Mark { get; set; }
    }
}