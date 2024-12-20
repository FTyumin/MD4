namespace MD4.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public Teacher Teacher { get; set; }

        public Course(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
            Assignments = new List<Assignment>();
        }
        public Course() { }
    }
}
