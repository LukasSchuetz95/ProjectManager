using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models.ViewModel;
using Task = ProjectManager.Core.Entities.Task;

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
        }

        [HttpPost]
        public IActionResult List(TasksListViewModel model)
        {
            model.Tasks = _unitOfWork.Tasks.GetTaskByName(model.FilterTaskName);
            return View(model);
        }

        public IActionResult FinishList()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

        }

        public IActionResult OpenList()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

            //return View();
        }
        public IActionResult InProgressList()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

            //return View();
        }


        public IActionResult Create(int projectId)
        {
            TasksCreateViewModel model = new TasksCreateViewModel();
           // model.Project.Id = projectId;
            model.LoadData(_unitOfWork, projectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TasksCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.EmployeeTasks.Add(model.EmployeeTask);
                    _unitOfWork.Save();
                    //  return RedirectToAction("Create", "EmployeeTasks", new { taskId = model.EmployeeTask.TaskId });
                    return RedirectToAction("List", "Projects");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);      
        }

        public IActionResult GeneraleCreate()
        {
            int projectId = 42458; 

            TasksCreateViewModel model = new TasksCreateViewModel();
            model.LoadData(_unitOfWork, projectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult GeneraleCreate(TasksCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.EmployeeTasks.Add(model.EmployeeTask);
                    _unitOfWork.Save();
                    //  return RedirectToAction("Create", "EmployeeTasks", new { taskId = model.EmployeeTask.TaskId });
                    return RedirectToAction("List", "Projects");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }

        public IActionResult Edit(int taskId, int projectId)
        {
            TasksEditViewModel model = new TasksEditViewModel();
            model.LoadData(_unitOfWork, taskId, projectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TasksEditViewModel model)
        {
           // EmployeeTask employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(model.Tasks.Id, model.EditEmployee.Id);

            if (ModelState.IsValid)
            {
                _unitOfWork.Tasks.Update(model.Tasks);
              //  _unitOfWork.EmployeeTasks.Update(employeeTask);
                _unitOfWork.Save();
                 return RedirectToAction(nameof(Details), new { taskId = model.Tasks.Id });
            }

            return View(model);
        }




        public IActionResult Details(int taskId)
        {
            TasksDetailsViewModel model = new TasksDetailsViewModel();
            model.LoadData(_unitOfWork, taskId);
            return View(model);
        }

        public IActionResult Delete(int taskId)
        {
            Task model = _unitOfWork.Tasks.GetById(taskId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int taskId)
        {
            Task model = _unitOfWork.Tasks.GetById(taskId);

            if (model == null)
            {
                return NotFound();
            }
            _unitOfWork.Tasks.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction(nameof(List));
        }
    }
}


