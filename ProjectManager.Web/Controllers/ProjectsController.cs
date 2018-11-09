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
    public class ProjectsController : Controller
    {
        IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult List(int projectId)
        {
            ProjectsListViewModel model = new ProjectsListViewModel();
            model.LoadData(_unitOfWork, projectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult List(ProjectsListViewModel model)
        {
            model.Projects = _unitOfWork.Projects.GetProjectByName(model.FilterProjectName);
            return View(model);
        }

        public IActionResult Edit(int projectId)
        {
            ProjectsEditViewModel model = new ProjectsEditViewModel();            
            model.Project = _unitOfWork.Projects.GetById(projectId);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProjectsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Projects.Update(model.Project);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Details), new { projectId = model.Project.Id });
            }

            return View(model);
        }

        public IActionResult Create(int projectId)
        {
            Project projects = new Project();
            projects = _unitOfWork.Projects.GetById(projectId);
            return View(projects);
        }

        [HttpPost]
        public IActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Projects.Add(model);
                    _unitOfWork.Save();
                    return RedirectToAction("List");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            model = _unitOfWork.Projects.GetById(model.Id);
            return View(model);
        }

        public IActionResult Details(int projectId)
        {
            ProjectsDetailsViewModel model = new ProjectsDetailsViewModel();
            model.Project = _unitOfWork.Projects.GetById(projectId);
            return View(model);
        }


    }
}