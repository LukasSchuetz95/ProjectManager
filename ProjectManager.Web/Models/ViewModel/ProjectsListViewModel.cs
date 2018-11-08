using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsListViewModel
    {
        public List<Project> Projects { get; set; }

        public string FilterProjectName { get; set; }
    }
}
