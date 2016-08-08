using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Contact
    {
        
        [Required]
        public string ContactName { get; set; }

        [Key]
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string ContactMessage { get; set; }
    }
}