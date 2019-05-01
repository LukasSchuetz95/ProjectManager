using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.Persistence
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;


        public AppointmentRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Appointment appointments)
        {
            _dbContext.Appointment.Add(appointments);
        }

        public List<Appointment> GetAll()
        {
            return _dbContext.Appointment.ToList();
        }

        public Appointment GetById(int appId)
        {
            return _dbContext.Appointment.Where(app => app.Id == appId).FirstOrDefault();
        }
    }
}
