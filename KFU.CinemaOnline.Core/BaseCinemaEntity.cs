using System.ComponentModel.DataAnnotations.Schema;

namespace KFU.CinemaOnline.Core
{
    public abstract class BaseCinemaEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}