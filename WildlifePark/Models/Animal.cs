using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WildlifePark.Models
{
    [Table("animals")]
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(0, 100,
            ErrorMessage = "Age must be between 0 and 100.")]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}