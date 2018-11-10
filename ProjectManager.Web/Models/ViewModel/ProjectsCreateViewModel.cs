using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsCreateViewModel
    {
        public EmployeeProject EmployeeProject { get; set; }

        public SelectList Employees { get; set; }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            var employees = unitOfWork.Employees.GetAll();
            Employees = new SelectList(employees, nameof(Employee.Id), null);
        }
    }
}
