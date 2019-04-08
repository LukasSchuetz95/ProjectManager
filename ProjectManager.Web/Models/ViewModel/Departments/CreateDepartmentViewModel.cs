using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel.Departments
{
    public class CreateDepartmentViewModel
    {
        public Department Department { get; set; }

        public bool Success { get; set; }

    }
}
