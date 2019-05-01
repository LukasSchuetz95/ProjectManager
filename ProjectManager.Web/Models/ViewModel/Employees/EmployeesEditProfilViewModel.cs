using Microsoft.AspNetCore.Mvc.Rendering;
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
        #region properties

        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public SelectList DepartmentSelectList { get; set; }
        public bool Error { get; set; }

        #endregion

        #region controller-methods

        public void LoadEditProfilData(IUnitOfWork uow, int employeeId)
        {
            Employee = uow.Employees.GetById(employeeId);

            List<Department> DepartmentList = uow.Departments.GetAllWithoutThisDepartmentId(Employee.DepartmentId);
            this.DepartmentSelectList = new SelectList(DepartmentList, nameof(Department.Id), nameof(Department.DeptName));
        }

        #endregion
              
    }
}
