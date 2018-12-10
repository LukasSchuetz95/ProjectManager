using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        IUnitOfWork _unitOfWork;

        public EmployeeProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Create(int projectId)
        {
            EmployeeProjectsCreateViewModel model = new EmployeeProjectsCreateViewModel();
            model.LoadData(_unitOfWork, projectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int empProId)
        {
            EmployeeProject model = _unitOfWork.EmployeeProjects.GetById(empProId);

            if (model == null)
            {
                return NotFound();
            }
            _unitOfWork.EmployeeProjects.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Create), new { projectId = model.ProjectId });
        }
    }
}