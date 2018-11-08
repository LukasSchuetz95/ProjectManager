using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;

namespace ProjectManager.Web.Controllers
{
    public class ProjectController : Controller
    {
        IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult List()
        {
            List<Project> projects = new List<Project>();
            projects = _unitOfWork.Projects.GetAll();
            return View(projects);
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


    }
}