using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public Category ParentCategory { get; set; } = null;


    }
}