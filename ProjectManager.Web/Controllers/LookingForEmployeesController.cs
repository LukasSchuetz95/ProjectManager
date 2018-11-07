﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class LookingForEmployeesController : Controller
    {
        IUnitOfWork _unitOfWork;

        public LookingForEmployeesController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult LookingFor()
        {
            LookingForEmployeesLookingForModel model = new LookingForEmployeesLookingForModel();
            model.Employees = _unitOfWork.Employees.GetEmployeeByLastname();
            return View(model);
        }

        [HttpPost]
        public IActionResult LookingFor(LookingForEmployeesLookingForModel model)
        {
            if (model.FilterFirstname == null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByLastname(model.FilterLastname);
                return View(model);
            }
            else
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByFirstname(model.FilterFirstname);
                return View(model);
            }
            
        }
    }
}