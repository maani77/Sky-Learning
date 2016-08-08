namespace MyProject.Models
{
    public class StudentQuiz
    {
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public double Marks { get; set; }

    }
}