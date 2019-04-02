using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;

namespace ProjectManager.Web.Models.ViewModel
{
    public class AppointmentListViewModel
    {
        public List<Appointment> Appointments;

        internal void LoadData(IUnitOfWork unitOfWork, int employeeId)
        {
            Appointments = unitOfWork.Appointments.GetByEmployee(employeeId);
        }
    }
}