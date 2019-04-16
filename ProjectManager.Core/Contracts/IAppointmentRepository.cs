using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Contracts
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        void Add(Appointment appointments);
        Appointment GetById(int appId);
    }
}
