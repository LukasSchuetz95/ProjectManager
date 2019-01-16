using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using TelerikAspNetCoreApp1.Models;

namespace TelerikAspNetCoreApp1.Controllers
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
    }

}