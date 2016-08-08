using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int stars { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}