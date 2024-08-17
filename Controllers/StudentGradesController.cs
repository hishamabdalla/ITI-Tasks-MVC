using ITI.Models;
using ITI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;
using System.Drawing;

namespace ITI.Controllers
{
    public class StudentGradesController : Controller
    {
        ITIEntity context=new ITIEntity();


        public IActionResult Details(int id)
        {
            Trainee traineeModel=context.Trainees.FirstOrDefault(t=>t.Id==id);
            CrsResult crsResultModel=context.CrsResult.FirstOrDefault(t=>t.Trainee_Id==id);
            Course courseModel=context.Courses.FirstOrDefault(t=>t.Id==id);

            TraineeDetailsViewModel traineeViewModel = new TraineeDetailsViewModel()
            {
                TraineeId = traineeModel.Id,
                TraineeName = traineeModel.Name,
                CourseName = courseModel.Name,
                Degree = crsResultModel.Degree,
                DegreeColor = crsResultModel.Degree >= courseModel.MinDegree ? "Green" : "Red"

            };

            return View(traineeViewModel);
        }
    }
}
