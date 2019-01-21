using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models
{
    public class EmployeesEditProfilViewModel
    {
        public Employee Employee { get; set; }
        public bool Success { get; set; }
        public void LoadEditProfilData(IUnitOfWork unitOfWork, int employeeId)
        {
            Employee = unitOfWork.Employees.GetById(employeeId);
        }        
    }
}
