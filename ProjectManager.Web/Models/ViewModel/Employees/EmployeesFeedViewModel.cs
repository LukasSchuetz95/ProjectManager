using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ProjectManager.Core.Entities.Task;

namespace ProjectManager.Web.Models.ViewModel.Employees
{
    public class EmployeesFeedViewModel
    {
        public EmployeeProject EmployeeProject { get; set; }
        public List<EmployeeTask> EmployeeTaskList { get; set; }
        public List<EmployeeQualification> EmployeeQualificationList { get; set; }
        public List<Task> TaskList { get; set; }

        public void LoadFeedData(int employeeId, IUnitOfWork unitOfWork)
        {
            EmployeeTaskList = unitOfWork.EmployeeTasks.GetTasksByEmployeeId(employeeId);

            EmployeeQualificationList = unitOfWork.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);

            TaskList = unitOfWork.Tasks.GetAll();
        }
    }
}
