using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel.Employees
{
    public class EmployeesFeedViewModel
    {
        public List<EmployeeProject> EmployeeProject { get; set; }

        //public Project Project { get; set; }

        //public List<EmployeeTask> EmployeeTask { get; set; }

    }
}
