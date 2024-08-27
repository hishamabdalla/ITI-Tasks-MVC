using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Unique]
        public string Name { get; set; }

        [Range(50,100,ErrorMessage ="The Degree Must Be Between 50 and 100")]
        public int Degree { get; set; }
        [Remote("CheckMinDegree","Course",AdditionalFields = "Degree",ErrorMessage ="Must be Less Than Degree")]
        public int MinDegree {  get; set; }
        [ForeignKey("Department")]
        [Display(Name ="Department Name")]
        public int Dept_Id { get; set; }

        public List<Instructor>? Instructors { get; set; }
        public List<CrsResult>? crsResults { get; set; }

        public Department? Department { get; set; }
    }
}
