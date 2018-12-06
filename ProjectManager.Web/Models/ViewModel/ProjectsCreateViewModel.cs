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

        public SelectList ProjectManagers { get; set; }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            List<EmployeeQualification> projectmanagers = unitOfWork.EmployeeQualifications.GetAllProjectManagers();
            ProjectManagers = new SelectList(projectmanagers, nameof(EmployeeQualification.EmployeeId), nameof(EmployeeQualification.Employee));
        }
    }
}
