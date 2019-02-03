using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksEditViewModel
    {
        public EmployeeTask EmployeeTask { get; set; }
        public Core.Entities.Task Task { get; set; }

        public SelectList Employees { get;  set; }
        public Core.Entities.Task Tasks { get; set; }
        public Employee EditEmployee { get; internal set; }
        public List<EmployeeProject> EmployeeProject { get; set; }

        public Qualification Qualification { get; set; }
        public List<Qualification> QualificationList { get; set; }
        public SelectList Qualifications { get; set; }

        public void LoadData(IUnitOfWork uow, int taskId, int projectId)
        {
            EmployeeTask = uow.EmployeeTasks.GetEmployeeTaskByTaskId(taskId);

            List<EmployeeProject> employees = uow.EmployeeProjects.GetAllByProjectId(projectId);
            Employees = new SelectList(employees, nameof(Employee.Id), nameof(Project.Id));
            Tasks = uow.Tasks.GetById(taskId);
            EmployeeProject = uow.EmployeeProjects.GetAllByProjectId(projectId);
            QualificationList = uow.Qualifications.GetAll();
            Qualifications = new SelectList(QualificationList, nameof(Qualification.Id));
        }

       
    }
}
