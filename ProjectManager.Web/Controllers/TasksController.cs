using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
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

        [HttpPost]
        public IActionResult FinishList(TasksListViewModel model)
        {
            TaskStatusType completetd = new TaskStatusType();
            completetd = TaskStatusType.Completed;

            model.CompletedTasks = _unitOfWork.Tasks.GetTaskByName(model.FilterTaskName, completetd );
            return View(model);

        }
        //Open,
        //Processing,
        //Completed,

        public IActionResult OpenList()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

        }

        [HttpPost]
        public IActionResult OpenList(TasksListViewModel model)
        {
            TaskStatusType open = new TaskStatusType();
            open = TaskStatusType.Open;

            model.UndefinedTasks = _unitOfWork.Tasks.GetTaskByName(model.FilterTaskName, open);
            return View(model);

        }


        public IActionResult InProgressList()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

        }

        [HttpPost]
        public IActionResult InProgressList(TasksListViewModel model)
        {
            TaskStatusType processing = new TaskStatusType();
            processing = TaskStatusType.Processing;

            model.ProcessingTasks = _unitOfWork.Tasks.GetTaskByName(model.FilterTaskName, processing);
            return View(model);

        }


        public IActionResult Create(int projectId)
        {


            TasksCreateViewModel model = new TasksCreateViewModel();
            // model.Project.Id = projectId;
            //model.LoadData(_unitOfWork, 6969);
            if (projectId != 0)
            {
                model.LoadData(_unitOfWork, projectId);

            }
            else
            {
                model.LoadData(_unitOfWork, 6969);
            }


            model.Project = _unitOfWork.Projects.GetById(model.ProjectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TasksCreateViewModel model)
        {

            model.Task.ProjectId = model.Project.Id;
            // model.EmployeeTask.Task.ProjectId = model.Project.Id;
            // model.EmployeeTask.Employee = nobody;

            // model.EmployeeTask.Task = model.Task;
            //  model.EmployeeTask.Employee.Id = model.EmployeeTask.EmployeeId;



            //   if (ModelState.IsValid)
            //{
            try
            {
                //EmployeeTask etask = new EmployeeTask();
                // etask.Task = model.Task;

                _unitOfWork.Tasks.Add(model.Task);

                // _unitOfWork.EmployeeTasks.Add(model.Task);
                //if (model.Employee.Id != 0)
                if (model.EmployeeTask.EmployeeId != 0)
                {
                    Employee emp = new Employee();
                    emp = _unitOfWork.Employees.GetById(model.EmployeeTask.EmployeeId);
                    model.EmployeeTask.Employee = emp;
                    //model.EmployeeTask.Employee = model.Employee;
                    // model.EmployeeTask.EmployeeId = model.Employee.Id;
                    model.EmployeeTask.Task = model.Task;
                    _unitOfWork.EmployeeTasks.Add(model.EmployeeTask);
                }

                //_unitOfWork.Tasks.Add(model.EmployeeTask.Task);
                //  _unitOfWork.EmployeeTasks.Add(model.EmployeeTask);
                //     _unitOfWork.EmployeeTasks.Add(etask);

                //_unitOfWork.EmployeeTasks.Add(model.Task);
                _unitOfWork.Save();
                //  return RedirectToAction("Create", "EmployeeTasks", new { taskId = model.EmployeeTask.TaskId });
                return RedirectToAction("List", "Projects");
                //return RedirectToAction("Create", "EmployeeTasks", new { projectId = model.EmployeeTask.Task.ProjectId , taskid = model.EmployeeTask.Task.Id, emptaskId = model.EmployeeTask.Id });

            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
            }
            //}

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
            // model.Task.ProjectId = model.Project.Id

            // model.EmployeeTask.Task.ProjectId = model.Project.Id;
            // model.EmployeeTask.Employee = nobody;

            // model.EmployeeTask.Task = model.Task;
            //  model.EmployeeTask.Employee.Id = model.EmployeeTask.EmployeeId;

            Project project = new Project();
            project = _unitOfWork.Projects.GetById(model.Tasks.ProjectId);
            model.Tasks.Project = project;

            //   if (ModelState.IsValid)
            //{

            // _unitOfWork.EmployeeTasks.Add(model.Task);
            //if (model.Employee.Id != 0)
            _unitOfWork.Tasks.Update(model.Tasks);
            _unitOfWork.Save();

            if (model.EmployeeTask.EmployeeId != 0)
            {
                Employee emp = new Employee();
                emp = _unitOfWork.Employees.GetById(model.EmployeeTask.EmployeeId);
                model.EmployeeTask.Employee = emp;
                //model.EmployeeTask.Employee = model.Employee;
                //model.EmployeeTask.EmployeeId = model.Employee.Id;
                model.EmployeeTask.Task = model.Tasks;
                //_unitOfWork.EmployeeTasks.Add(model.EmployeeTask);

                _unitOfWork.EmployeeTasks.Update(model.EmployeeTask);

                _unitOfWork.Save();
            }






            return RedirectToAction("List", "Tasks");








            // EmployeeTask employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(model.Tasks.Id, model.EditEmployee.Id);

            //if (ModelState.IsValid)
            //{

            //  _unitOfWork.EmployeeTasks.Update(employeeTask);
            //    _unitOfWork.Save();
            //    return RedirectToAction(nameof(Details), new { taskId = model.Tasks.Id });
            //}

            //return View(model);
        }

        public IActionResult Details(int taskId)
        {
            TasksDetailsViewModel model = new TasksDetailsViewModel();
            model.LoadData(_unitOfWork, taskId);
            model.Task.Project = _unitOfWork.Projects.GetById(model.Task.ProjectId);
            return View(model);
        }

        public IActionResult Delete(int taskId)
        {
            Task model = _unitOfWork.Tasks.GetById(taskId);
            model.Project = _unitOfWork.Projects.GetById(model.ProjectId);
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


