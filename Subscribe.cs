using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Subscribe
    {
        [Key]
        [Required]
        public string Email { get; set; }
    }
}