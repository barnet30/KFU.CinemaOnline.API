using System;
using System.ComponentModel.DataAnnotations;

namespace KFU.CinemaOnline.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
