using ITI.Models;
using ITI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    public class CourseController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult Index()
        {
            List<Course> courses = context.Courses.ToList();
            List<Department> departments = context.Departments.ToList();
            var courseAndDepartmentName = courses.Select(cr => new CourseAndDepartmentNameViewModel
            {
                Id = cr.Id,
                CourseName = cr.Name,
                Degree = cr.Degree,
                MinDegree = cr.MinDegree,
                DepartmentName = departments.FirstOrDefault(d => d.Id == cr.Dept_Id)?.Name
            });

            return View(courseAndDepartmentName);
        }

        public IActionResult New()
        {
            ViewData["DeptList"] = context.Departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course course)
        {
            if (course.Name != null)
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["DeptList"] = context.Departments.ToList();

                return View("New", course);
            }

           
        }

        public IActionResult Edit(int id)
        {
            var courses = context.Courses.FirstOrDefault(c => c.Id == id);
            ViewData["DeptList"] = context.Departments.ToList();

            return View(courses);
        }

        public IActionResult SaveEdit(Course courseFromRequest)
        {
            if (courseFromRequest.Name != null)
            {
                Course courseFromDb = context.Courses.FirstOrDefault(c => c.Id == courseFromRequest.Id);
                courseFromDb.Name = courseFromRequest.Name;
                courseFromDb.Degree = courseFromRequest.Degree;
                courseFromDb.MinDegree = courseFromRequest.MinDegree;
                courseFromDb.Dept_Id = courseFromRequest.Dept_Id;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["DeptList"] = context.Departments.ToList();
                return View("Edit", courseFromRequest);
            }
        }


    }
}
