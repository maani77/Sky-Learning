using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Question
    {
        
        public Quiz Quiz { get; set; }
        [Required]
        public int QuizId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public virtual List<AnswerChoice> AnswerChoices { get; set; }
    }
}