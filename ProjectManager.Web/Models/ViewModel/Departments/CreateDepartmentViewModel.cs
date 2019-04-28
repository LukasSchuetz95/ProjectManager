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
        #region properties

        public Department Department { get; set; }

        public bool Success { get; set; }
        public bool Error { get; set; }

        public string RouteString { get; set; }
        public int RouteId { get; set; }

        #endregion

        #region controller-methods

        public void LoadData(string routeString, int routeId)
        {
            RouteString = routeString;
            RouteId = routeId;
        }

        #endregion
    }
}
