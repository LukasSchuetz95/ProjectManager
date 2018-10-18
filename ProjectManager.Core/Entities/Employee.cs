using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Employee : EntityObject
    {
        public List<EmployeeQualification> EmployeeQualifications { get; set; }

        public List<Task> Tasks { get; set; }

        public List<Appointment> Appointments { get; set; }

        public Department Department { get; set; }

        public User User { get; set; }

        public string Firstname { get; set; }

        public string lastname { get; set; }

        public string Job { get; set; }

        public bool Projectmanager { get; set; }

        public string Status { get; set; }

        public int Profilepicture { get; set; }

        public DateTime Birthdate { get; set; }

        public string Adress { get; set; }

        public string ZipCode { get; set; }

        public string Location { get; set; }

        public DateTime HiringDate { get; set; }

        public string Phonenumber { get; set; }

        public string Email { get; set; }
    }
}
