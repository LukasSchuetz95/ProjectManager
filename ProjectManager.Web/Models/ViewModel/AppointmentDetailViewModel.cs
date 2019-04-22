using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class AppointmentDetailViewModel
    {

        public Appointment Appointment { get; set; }

        public void LoadData(IUnitOfWork uow, int appId)
        {
            Appointment = uow.Appointments.GetById(appId);
        }

    }
}
