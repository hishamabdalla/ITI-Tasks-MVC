using ITI.Models;
using ITI.Repository;
using ITI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepo;
        IDepartmentRepository DeptRepo;

        public CourseController(ICourseRepository courseRepo, IDepartmentRepository deptRepo)
        {
            this.courseRepo = courseRepo;
            this.DeptRepo = deptRepo;
        }


        public IActionResult CheckMinDegree(int MinDegree,int Degree)
        {
           
            if (MinDegree < Degree) 
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Index()
        {
            List<Course> courses = courseRepo.GetAll();
            List<Department> departments = DeptRepo.GetAll();
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
            ViewData["DeptList"] = DeptRepo.GetAll().ToList();
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult SaveNew(Course course)
        {
            if (ModelState.IsValid)
            {
                  courseRepo.Add(course);
                    return RedirectToAction("Index");   
            }
            else
            {
                ViewData["DeptList"] = DeptRepo.GetAll().ToList();
                return View("New", course);
            }

             
        }

        public IActionResult Edit(int id)
        {
            var courses = courseRepo.GetById(id);
            ViewData["DeptList"] = DeptRepo.GetAll().ToList();

            return View(courses);
        }
        
        public IActionResult SaveEdit(Course courseFromRequest,int id)
        {
            if (courseFromRequest.Name != null)
            {
                courseRepo.Update(id, courseFromRequest);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["DeptList"] = DeptRepo.GetAll().ToList();
                return View("Edit", courseFromRequest);
            }
        }
        public IActionResult Delete(int id)
        {
           courseRepo.Delete(id);
            return RedirectToAction("Index", "Course");
        }



    }
}
