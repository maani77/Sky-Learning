using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class StudentCourse
    {
        [Required]
        [Key]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Key]
        public string StudentId { get; set; }
        public  ApplicationUser Student { get; set; }

    }
}