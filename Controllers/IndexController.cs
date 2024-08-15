using ITI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    public class TraineeController : Controller
    {
        ITIEntity context=new ITIEntity();
        public IActionResult Index()
        {
            //Get All Trainees
            List<Trainee> traineesModel= context.Trainees.ToList();

            return View(traineesModel);
        }

        public IActionResult Details(int id) 
        {
            Trainee traineeDetails =context.Trainees.FirstOrDefault(t=>t.Id==id);
            return View(traineeDetails);
        }

    }
}
