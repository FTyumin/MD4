using System.ComponentModel.DataAnnotations;

namespace MD4.Models
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime ContractDate { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public Teacher(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;

        }
        public Teacher() { }
    }
}

