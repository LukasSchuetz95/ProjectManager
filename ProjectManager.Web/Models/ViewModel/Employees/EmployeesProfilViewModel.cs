using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class EmployeesProfilViewModel
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Qualification Qualification { get; set; }

        public List<EmployeeProject> projectOfEmployee { get; set; }

        public SelectList QualificationSelectList { get; set; }

        public void LoadProfilData(IUnitOfWork uow, int employeeId)
        {
            Employee = uow.Employees.GetById(employeeId);

            uow.Departments.GetAll();

            projectOfEmployee = uow.EmployeeProjects.GetProjectsByEmployeeId(employeeId);

            List<EmployeeQualification>  employeeQualifications = uow.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);
            QualificationSelectList = new SelectList(employeeQualifications, nameof(Qualification.Id), nameof(Qualification.QualificationName));
        }
    }
}
