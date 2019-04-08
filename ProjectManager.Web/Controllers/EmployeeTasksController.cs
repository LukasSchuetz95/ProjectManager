using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class EmployeeTasksController : Controller
    {
        IUnitOfWork _unitOfWork;

        public EmployeeTasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     
        public IActionResult Create(int taskId, int projectId)
        {
            EmployeeTasksCreateViewModel model = new EmployeeTasksCreateViewModel();
            model.LoadData(_unitOfWork, taskId, projectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create( int taskId)
        {

            EmployeeTask model = new EmployeeTask {  TaskId = taskId };

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.EmployeeTasks.Add(model);
                    _unitOfWork.Save();
                    return RedirectToAction("Create", new { taskId = model.TaskId });
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int empTaskId)
        {
            EmployeeTask model = _unitOfWork.EmployeeTasks.GetById(empTaskId);

            if (model == null)
            {
                return NotFound();
            }
            _unitOfWork.EmployeeTasks.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Create), new { taskId = model.TaskId});
        }

    }
}