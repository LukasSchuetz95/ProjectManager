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
        #region fields

        private List<Task> _poolTasks = new List<Task>();

        #endregion

        #region Properties

        public Employee Employee { get; set; }

        public List<EmployeeTask> EmployeeAssignedTasksList { get; set; }
        public List<EmployeeQualification> EmployeeQualifications { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }

        public List<DashboardDisplay> DashboardTasks { get; set; }

        public List<EmployeeTask> AssignedTasks { get; set; }
        public List<Task> PoolTasks { get => _poolTasks; set => _poolTasks = value; }

        public string Assigned { get; set; }
        public string ProjectFilter { get; set; }
        public string GeneralFilter { get; set; }
        public string PriorityFilter { get; set; }
        //public string AddTask { get; set; }

        public string ButtonClicked { get; set; }
        public string Search { get; set; }
        public string SearchInput { get; set; }

        #endregion

        #region Controller-Methods

        public void LoadDashboardData(int employeeId, IUnitOfWork uow)
        {
            this.Employee = uow.Employees.GetById(employeeId);
            this.ButtonClicked = "Assigned";

            LoadDashboardDisplays(uow, employeeId);

            EmployeeAssignedTasksList = uow.EmployeeTasks.GetAllByEmployeeId(employeeId);

            FillPoolTaskList();
        }

        public void LoadProjectDashboardData(int employeeId, IUnitOfWork uow, string project, bool priority)
        {
            EmployeeQualifications = uow.EmployeeQualifications.GetQualificationsByEmployeeId(employeeId);

            EmployeeProjects = uow.EmployeeProjects.GetProjectsByEmployeeId(employeeId);

            this.PoolTasks.AddRange(uow.Tasks.GetProjectTasksByEmployeeQualification(EmployeeQualifications, EmployeeProjects, uow, project));           

            RemoveAssignedTasks(uow, employeeId);

            LoadDashboardDisplays(uow, employeeId);

            if (priority)
                RemoveLowPriorityTasks();
        }

        #endregion      

        #region Model-Methods

        public void LoadDashboardDisplays(IUnitOfWork uow, int employeeId)
        {
            this.DashboardTasks = uow.DashboardDisplays.GetByEmployeeId(employeeId);
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

        private void FillPoolTaskList()
        {
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

        public void RemoveLowPriorityTasks()
        {
            List<Task> checkTasks = new List<Task>();
            checkTasks.AddRange(this.PoolTasks);

                foreach (var obj in checkTasks)
                {
                    if (obj.Priority != Core.Enum.PriorityType.High)
                    {
                        PoolTasks.Remove(obj);
                    }
                }            
        }
        #endregion

        #region View-Methods

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
            return this.PoolTasks.Where(t => t.Priority == Core.Enum.PriorityType.High).Count();
        }

        #endregion
    }
}
