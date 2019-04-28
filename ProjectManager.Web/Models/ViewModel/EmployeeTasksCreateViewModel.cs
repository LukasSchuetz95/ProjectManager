using Microsoft.AspNetCore.Mvc.Rendering;
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
        public EmployeeProject EmployeeProject { get; set; }

        public EmployeeTask EmployeeInTask { get; set; }

        public EmployeeTask EmployeeTask { get; set; }

        public List<Employee> EmplyoeeNotInTask { get; set; }

        public Core.Entities.Task Task { get; set; }

        public List<EmployeeProject> Employees { get; set; }



        public void LoadData(IUnitOfWork unitOfWork, int projectId, int taskId, int emptaskId)
        {
            EmployeeProject = unitOfWork.EmployeeProjects.GetById(projectId);

            EmployeeInTask = unitOfWork.EmployeeTasks.GetById(taskId);

            Employees = unitOfWork.EmployeeProjects.GetAllByProjectId(projectId);

            EmployeeTask = unitOfWork.EmployeeTasks.GetById(emptaskId);

            Task = unitOfWork.Tasks.GetById(taskId);
        }



    }
}
