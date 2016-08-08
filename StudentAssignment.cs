using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class StudentAssignment
    {
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

    }
}