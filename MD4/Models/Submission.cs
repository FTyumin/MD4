using System.ComponentModel.DataAnnotations;

namespace MD4.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionTime { get; set; }
        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                //pārbauda, vai ievadītā vērtība nav negatīva vai lielāka par 100
                if (value < 0 || value > 100)
                {
                    throw new Exception("Score must be between 0 and 100");
                }
                else { score = value; }
            }
        }

        public Student? Student { get; set; }
        public Assignment? Assignment { get; set; }
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
