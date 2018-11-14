using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;

namespace ProjectManager.Web.Controllers
{
    public class QualificationsController : Controller
    {
        IUnitOfWork _unitOfWork;

        public QualificationsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult List()
        {
            //ProjectsListViewModel model = new ProjectsListViewModel();
            //model.LoadData(_unitOfWork, projectId);
            //return View(model);

            List<Qualification> qualifications = _unitOfWork.Qualifications.GetAll();
            return View(qualifications);
        }
    }
}