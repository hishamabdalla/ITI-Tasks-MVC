using ITI.Models;

namespace ITI.ViewModel
{
    public class CourseAndDepartmentNameViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        public int Dept_Id {  get; set; }
        public string DepartmentName { get; set; }

    }
}
