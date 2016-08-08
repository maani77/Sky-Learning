using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
        [ScaffoldColumn(false)]
        public int Rating { get; set; }

        public virtual ICollection<StudentCourse> Enrollments { get; set; }
    }
}