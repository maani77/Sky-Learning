using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Certificate
    {
        [Key]
        [Required]
        public int CertificateId { get; set; }
        [Required]
        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}