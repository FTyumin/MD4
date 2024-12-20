namespace MD4.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }

        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public Submission(int id, int assignmentId, int studentId, DateTime submissionTime, int score)
        {
            Id = id;
            AssignmentId = assignmentId;
            StudentId = studentId;
            SubmissionTime = submissionTime;
            Score = score;
        }

        public Submission() { }
    }
}
