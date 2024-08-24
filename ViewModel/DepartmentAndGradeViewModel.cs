using ITI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.ViewModel
{
    public class DepartmentAndGradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public List<string> Grade { get; set; }
        public List<Department> departments { get; set; }
        public int? Dept_Id { get; set; }

    }
}
