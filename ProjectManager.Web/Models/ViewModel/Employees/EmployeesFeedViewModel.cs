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
        private List<Task> _poolTasks = new List<Task>();

        public Employee Employee { get; set; }

        public List<EmployeeTask> EmployeeAssignedTasksList { get; set; }
        public List<EmployeeQualification> EmployeeQualifications { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }

        public List<DashboardDisplay> DashboardTasks { get; set; }

        public List<EmployeeTask> AssignedTasks { get; set; }
        public List<Task> PoolTasks { get => _poolTasks; set => _poolTasks=value; }
        public List<Appointment> AppointmentList { get; set; }

        public string Assigned { get; set; }
        public string ProjectFilter { get; set; }
        public string GeneralFilter { get; set; }
        public string PriorityFilter { get; set; }
        public string AddTask { get; set; }

        public string ButtonClicked { get; set; }
        public string Search { get; set; }
        public string SearchInput { get; set; }

        //public string ErrorMessage { get; set; }
        //public bool ErrorCreateEmployeeTask { get; set; }

        public void LoadFeedData(int employeeId, IUnitOfWork uow)
        {
            EmployeeAssignedTasksList = uow.EmployeeTasks.GetAllByEmployeeId(employeeId);

            LoadDashboardTasks(uow, employeeId);

            Task task = new Task();

            foreach (var ele in this.EmployeeAssignedTasksList)
            {
                task.Id = ele.Task.Id;
                task.TaskName = ele.Task.TaskName;
                task.Information = ele.Task.Information;
                task.Priority = ele.Task.Priority;

                PoolTasks.Add(task);
                task = new Task();
            }
        }

        public void LoadProjectFeedData(int employeeId, IUnitOfWork uow)
        {
            EmployeeQualifications = uow.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);

            EmployeeProjects = uow.EmployeeProjects.GetProjectsByEmployeeId(employeeId);

            this.PoolTasks.AddRange(uow.Tasks.GetProjectTasksByEmployeeQualification(EmployeeQualifications, EmployeeProjects, uow, "All"));

            RemoveAssignedTasks(uow, employeeId);

            LoadDashboardTasks(uow, employeeId);
        }

        public void LoadGeneralFeedData(int employeeId, IUnitOfWork uow)
        {
            EmployeeQualifications = uow.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);

            EmployeeProjects = uow.EmployeeProjects.GetProjectsByEmployeeId(employeeId);

            this.PoolTasks.AddRange(uow.Tasks.GetProjectTasksByEmployeeQualification(EmployeeQualifications, EmployeeProjects, uow, "General"));

            RemoveAssignedTasks(uow, employeeId);

            LoadDashboardTasks(uow, employeeId);
        }

        private void RemoveAssignedTasks(IUnitOfWork uow, int employeeId)
        {
            List<Task> fakePoolTasks = new List<Task>();
            fakePoolTasks.AddRange(this.PoolTasks);

            this.AssignedTasks = uow.EmployeeTasks.GetAllExceptFromEmployeeId(employeeId);

            foreach (var fPT in fakePoolTasks)
            {
                foreach (var aT in AssignedTasks)
                {
                    if (fPT.Id == aT.TaskId)
                    {
                        this.PoolTasks.Remove(fPT);
                    }
                }
            }
        }

        public void LoadDashboardTasks(IUnitOfWork uow, int employeeId)
        {
            this.DashboardTasks = uow.DashboardDisplays.GetByEmployeeId(employeeId);
        }

        #region ViewMethods

        public bool IsTaskVisible(Task tsk)
        {
            if (SearchInput != null)
            {
                return tsk.TaskName.ToUpper().Contains(SearchInput.ToUpper());
            }
            else
            {
                return true;
            }
        }

        public int CountHighPriorityTasks()
        {
            return this.PoolTasks.Where(p => p.Priority == Core.Enum.PriorityType.High).Count();
        }

        #endregion
    }
}
