using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsEditViewModel
    {
        public Project Project { get; set; }

        public void LoadData(IUnitOfWork uow, int id)
        {
            Project = uow.Projects.GetById(id);
        }
    }
}
