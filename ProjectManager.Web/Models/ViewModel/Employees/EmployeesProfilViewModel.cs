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
        #region fields

        private List<Qualification> qualificationList = new List<Qualification>();

        #endregion

        #region Properties

        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Qualification Qualification { get; set; }

        public string Hiringdate { get; set; }
        public string Birthdate { get; set; }


        public List<EmployeeProject> ProjectOfEmployee { get; set; } 

        public List<EmployeeQualification> EmployeeQualifications { get; set; }
        public List<Qualification> QualificationList { get=> qualificationList; private set=> qualificationList=value; }
        public SelectList QualificationSelectList { get; set; }

        #endregion

        #region Controller-methods
        public void LoadProfilData(IUnitOfWork uow, int employeeId)
        {
            Employee = uow.Employees.GetById(employeeId);

            Hiringdate = (((DateTime)this.Employee.HiringDate).Date.ToString("d"));
            Birthdate = (((DateTime)this.Employee.Birthdate).Date.ToString("d"));

            uow.Departments.GetAll();

            ProjectOfEmployee = uow.EmployeeProjects.GetProjectsByEmployeeId(employeeId);
            CreateQualificationList(uow, employeeId);
            QualificationSelectList = new SelectList(QualificationList, nameof(Qualification.Id), nameof(Qualification.QualificationName));
        }

        #endregion

        #region Model-methods

        private void CreateQualificationList(IUnitOfWork uow, int employeeId)
        {
            EmployeeQualifications = uow.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);
            QualificationList = new List<Qualification>();
            foreach (var obj in EmployeeQualifications)
            {
                QualificationList.Add(obj.Qualification);
            }

        } 

        #endregion
    }
}

