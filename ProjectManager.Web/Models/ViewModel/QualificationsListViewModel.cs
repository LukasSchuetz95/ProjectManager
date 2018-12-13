using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class QualificationsListViewModel
    {
        public List<Qualification> Qualifications { get; set; }

        public string FilterProjectName { get; set; }

        public void LoadData(IUnitOfWork uow)
        {
            Qualifications = uow.Qualifications.GetAll();
        }
    }
}
