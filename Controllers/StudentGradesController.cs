using ITI.Models;
using ITI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using System.Drawing;

namespace ITI.Controllers
{
    public class StudentGradesController : Controller
    {
        ITIEntity context=new ITIEntity();


        public IActionResult Details(int id)
        {
            Trainee traineeModel = context.Trainees.FirstOrDefault(t => t.Id == id);
            CrsResult crsResultModel = context.CrsResult.FirstOrDefault(t => t.Trainee_Id == id);
            Course courseModel = context.Courses.FirstOrDefault(t => t.Name == "C#");

            var traineeViewModel = new TraineeDetailsViewModel()
            {
                TraineeId = traineeModel.Id,
                TraineeName = traineeModel.Name,
                CourseName = courseModel.Name,
                Degree = crsResultModel.Degree,
                DegreeColor = crsResultModel.Degree >= courseModel.MinDegree ? "Green" : "Red"
            };

            return View(traineeViewModel);
        }
        public IActionResult AllGrades(int id)
        {
            var traineeModel = context.Trainees.FirstOrDefault(t => t.Id == id);
            var crsResults = context.CrsResult.Where(c => c.Trainee_Id == id).ToList();
            var courses = context.Courses.ToList();

            var traineeCourses = crsResults
                .Select(cr => new TraineeDetailsViewModel
                {
                    CourseName = courses.FirstOrDefault(c => c.Id == cr.Crs_Id)?.Name,
                    Degree = cr.Degree,
                    DegreeColor = cr.Degree >= 60 ? "Green" : "Red"
                })
                .ToList();

            var traineeViewModel = new TraineeDetailsViewModel()
            {
                TraineeId = traineeModel.Id,
                TraineeName = traineeModel.Name,
                trainneCourses = traineeCourses
            };

            return View(traineeViewModel);
        }
    }
}
    

