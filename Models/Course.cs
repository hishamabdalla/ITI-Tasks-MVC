using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree {  get; set; }
        [ForeignKey("Department")]
        [Display(Name ="Department Name")]
        public int Dept_Id { get; set; }

        public List<Instructor>? Instructors { get; set; }
        public List<CrsResult>? crsResults { get; set; }

        public Department? Department { get; set; }
    }
}
