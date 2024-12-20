namespace MD4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int StudentIdNumber { get; set; }

        public ICollection<Submission> Submissions { get; set; }


        public Student(int id, string name, string surname, string gender, int studentIdNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Gender = gender;
            StudentIdNumber = studentIdNumber;
        }

        public Student() { }
    }
}
