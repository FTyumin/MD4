using System.ComponentModel.DataAnnotations;

namespace MD4.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
        Course Course { get; set; }

        public ICollection<Submission>? Submissions { get; set; }

        public Assignment(int id, DateTime deadline, int courseId, string description)
        {
            Id = id;
            Deadline = deadline;
            CourseId = courseId;
            Description = description;
        }
        //public Assignment() { }
    }
}
