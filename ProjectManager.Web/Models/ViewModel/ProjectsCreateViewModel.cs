using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsCreateViewModel
    {
        public Project Project { get; set; }
        public SelectList Statuses { get; set; }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            var statuses = unitOfWork.Projects.GetAllStatuses();
            Statuses = new SelectList(statuses, nameof(Project.Status), null);
        }
    }
}
