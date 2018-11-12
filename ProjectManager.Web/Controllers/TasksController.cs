using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult List()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

            //return View();
        }

        public IActionResult Create()
        {
            TasksCreateViewModel model = new TasksCreateViewModel();
            model.LoadData(_unitOfWork);
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Create(TasksCreateViewModel model )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _unitOfWork.EmployeeTasks.Add(model.EmployeeTask);
        //            _unitOfWork.Save();
        //            return RedirectToAction("List", "Tasks");
        //        }
        //        catch (ValidationException validationException)
        //        {
        //            ValidationResult valResult = validationException.ValidationResult;
        //            ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
        //        }
        //    }

        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Create(TasksCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Tasks.Add(model.EmployeeTask.Task);
                    _unitOfWork.Save();
                    return RedirectToAction("List", "Tasks");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }


        public IActionResult Edit(int taskId)
        {
            TasksEditViewModel model = new TasksEditViewModel();
            model.LoadData(_unitOfWork, taskId);
            return View(model);
        }

        public IActionResult Details(int taskId)
        {
            TasksDetailsViewModel model = new TasksDetailsViewModel();
            model.LoadData(_unitOfWork, taskId);
            return View(model);
        }
    }
}