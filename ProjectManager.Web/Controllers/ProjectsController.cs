using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class ProjectsController : Controller
    {
        IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult List()
        {
            
            ProjectsListViewModel model = new ProjectsListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);
        }

        [HttpPost]
        public IActionResult List(ProjectsListViewModel model)
        {
            model.Projects = _unitOfWork.Projects.GetProjectByName(model.FilterProjectName);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int projectId)
        {
            ProjectsEditViewModel model = new ProjectsEditViewModel();
            model.LoadData(_unitOfWork, projectId);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ProjectsEditViewModel model)
        {
            Employee employee = _unitOfWork.Employees.GetById(model.EditEmployee.Id);

            _unitOfWork.EmployeeProjects.SetAllProjectManagersToFalse(model.Project.Id);

            EmployeeProject employeeProject = _unitOfWork.EmployeeProjects.GetByEmployeeIdAndProjectId(model.Project.Id, model.EditEmployee.Id);

            employeeProject.Projectmanager = true;

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Projects.Update(model.Project);
                    _unitOfWork.EmployeeProjects.Update(employeeProject);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(List));
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
                
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ProjectsCreateViewModel model = new ProjectsCreateViewModel();
            model.LoadData(_unitOfWork);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProjectsCreateViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    model.EmployeeProject.Projectmanager = true;
                    _unitOfWork.Projects.Add(model.EmployeeProject.Project);
                    _unitOfWork.EmployeeProjects.Add(model.EmployeeProject);
                    _unitOfWork.Save();
                    return RedirectToAction("Create", "EmployeeProjects", new { projectId = model.EmployeeProject.ProjectId });
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }


        public IActionResult Details(int projectId)
        {
            ProjectsDetailsViewModel model = new ProjectsDetailsViewModel();
            model.LoadData(_unitOfWork, projectId);
            return View(model);   
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int projectId)
        {
            Project model = _unitOfWork.Projects.GetById(projectId);

            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirm(int projectId)
        {
            Project model = _unitOfWork.Projects.GetById(projectId);

            if(model == null)
            {
                return NotFound();
            }
            _unitOfWork.Projects.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction(nameof(List));
        }

    }
}