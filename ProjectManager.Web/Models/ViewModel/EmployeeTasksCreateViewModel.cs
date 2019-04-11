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

        public List<Employee> EmplyoeeNotInProject { get; set; }



        public void LoadData(IUnitOfWork unitOfWork, int projectId, int taskId)
        {
            EmployeeProject = unitOfWork.EmployeeProjects.GetById(projectId);

            EmployeeInTask = unitOfWork.EmployeeTasks.GetById(taskId);

            EmplyoeeNotInProject = unitOfWork.EmployeeTasks.GetAllWithProjectID(projectId, taskId);

            EmployeeTask = unitOfWork.EmployeeTasks.GetById(taskId);
        }



    }
}
