using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Department")]
        public int? Dept_Id {  get; set; }
        [ForeignKey("Course")]
        public int Crs_ID {  get; set; }

        public Department? Department { get; set; }
        public Course? Course { get; set; }

    }
}
