using ITI.Models;
using ITI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ITI.Controllers
{
    public class TraineeController : Controller
    {
        ITIEntity context = new ITIEntity();

        public IActionResult Index()
        {
            List<Department> departmentsModel = context.Departments.ToList();
            //Get All Trainees
            List<Trainee> traineesModel = context.Trainees.ToList();

            var traineeAndDept = traineesModel.Select(tr => new TraineeWithDepartmentNameViewModel
            {
                Id = tr.Id,
                TraineeName = tr.Name,
                Address = tr.Address,
                DepartmentName = departmentsModel.FirstOrDefault(d => d.Id == tr.Dept_Id)?.Name,
                Grade = tr.Grade,
                Image = tr.Image,
            }).ToList();

            return View(traineeAndDept);
        }

        public IActionResult Details(int id)
        {
            Trainee traineeDetails = context.Trainees.FirstOrDefault(t => t.Id == id);
            Department department = context.Departments.FirstOrDefault(d => d.Id == traineeDetails.Dept_Id);
            TraineeWithDepartmentNameViewModel traineeWithDepartment = new TraineeWithDepartmentNameViewModel()
            {
                Id= traineeDetails.Id,
                TraineeName = traineeDetails.Name,
                Address = traineeDetails.Address,
                DepartmentName = department.Name,
                Grade = traineeDetails.Grade,
                Image = traineeDetails.Image,

            };
            return View(traineeWithDepartment);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = context.Departments.ToList();
            ViewBag.Grade = new List<string>() { "Level 1", "Level 2", "Level 3", "Level 4" };

            return View();
        }


        [HttpGet]
        public IActionResult SaveNew(Trainee trainee)
        {
            if (trainee.Name != null)
            {
                context.Trainees.Add(trainee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.Departments.ToList();
            ViewBag.Grade = new List<string>() { "Level 1", "Level 2", "Level 3", "Level 4" };
            return View("New", trainee);
        }

        public IActionResult Edit(int id)
        {
            var trainee = context.Trainees.FirstOrDefault(x => x.Id == id);
            ViewData["DeptList"] = context.Departments.ToList();
            ViewBag.Grade = new List<string>() { "Level 1", "Level 2", "Level 3", "Level 4" };
            return View(trainee);
        }
        public IActionResult SaveEdit(Trainee traineeFromRequest)
        {
            if (traineeFromRequest.Name != null)
            {
                Trainee traineesFromDb=context.Trainees.FirstOrDefault(T=>T.Id== traineeFromRequest.Id);
                traineesFromDb.Name= traineeFromRequest.Name;
                traineesFromDb.Address= traineeFromRequest.Address;
                traineesFromDb.Grade = traineeFromRequest.Grade;
                traineesFromDb.Image = traineeFromRequest.Image;
                traineesFromDb.Dept_Id=traineeFromRequest?.Dept_Id;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.Departments.ToList();
            ViewBag.Grade = new List<string>() { "Level 1", "Level 2", "Level 3", "Level 4" };
            return View("Edit", traineeFromRequest);
        }
    }
}