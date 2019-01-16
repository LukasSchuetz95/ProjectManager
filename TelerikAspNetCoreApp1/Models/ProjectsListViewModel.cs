using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikAspNetCoreApp1.Models
{
    public class ProjectsListViewModel
    {
        public IEnumerable<Project> Projects { get; set; }

        public string FilterProjectName { get; set; }

        public void LoadData(IUnitOfWork uow)
        {
            Projects = uow.Projects.GetAll();
        }
    }
}
