using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class EmployeeTasksCreateViewModel
    {
        public EmployeeTask EmployeeTasks { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; }

        public EmployeeProject EmployeeProject { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int taskId, int projectId)
        {
            EmployeeTasks = unitOfWork.EmployeeTasks.GetByTaskId(taskId);
            EmployeeProject = unitOfWork.EmployeeProjects.GetById(projectId);
        }

        //internal void LoadData(IUnitOfWork unitOfWork, int taskId)
        //{

        //    EmployeeProjects = unitOfWork.EmployeeProjects.GetAllByProjectId(projectId);
        //}
    }
}
