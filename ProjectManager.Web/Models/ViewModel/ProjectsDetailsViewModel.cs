using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsDetailsViewModel
    {
        public Project Project { get; set; }

        public List<Core.Entities.Task> Tasks { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
