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
        public List<EmployeeQualification> EmployeeQualificationList { get; set; }
        public List<TaskQualification> TaskQualificationList { get; set; }
        public List<EmployeeTask> EmployeeTaskList { get; set; }
        public List<Task> WorkTasks { get; set; }
        public Task ChoosenTask { get; set; }

        public string ProjectFilter { get; set; }
        public string GeneralFilter { get; set; }
        public string PriorityFilter { get; set; }
        public string AddTask { get; set; }

        public void LoadFeedData(int employeeId, IUnitOfWork unitOfWork)
        {
            EmployeeQualificationList = unitOfWork.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);

            EmployeeTaskList = unitOfWork.EmployeeTasks.GetTasksByEmployeeIdAndQualifications(employeeId, EmployeeQualificationList);
        }

        public void LoadWorkTasks()
        {
            WorkTasks = new List<Task>();
        }
    }
}
