using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }
        [Required]
        public string LectureName { get; set; }
        
        public Course Course { get; set; }
        public int CourseId { get; set; }
        
        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}