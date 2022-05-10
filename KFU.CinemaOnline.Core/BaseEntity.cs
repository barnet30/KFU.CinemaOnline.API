using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFU.CinemaOnline.Core
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
