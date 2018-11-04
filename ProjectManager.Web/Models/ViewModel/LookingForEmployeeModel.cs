using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models
{
    public class LookingForEmployeeModel
    {
        public List<Employee> Employees { get; set; }
        [Display(Name = "LookingForEmployee")]
        public string Filter { get; set; }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            List<Employee> employees = unitOfWork.Employees.GetAll();
        }
    }
}
