using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;

namespace ProjectManager.Core.Entities
{
    public class Employee : EntityObject
    {
        public List<EmployeeQualification> EmployeeQualifications { get; set; }

        public List<EmployeeTask> EmployeeTasks { get; set; }

        public List<Appointment> Appointments { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public User User { get; set; }

        //public int UserId { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Vorname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Nachname")]
        public string Lastname { get; set; }

        [Display(Name = "Job-Name")]
        public string Job { get; set; }

        [Display(Name = "Projekt-Manager")]
        public bool Projectmanager { get; set; }

        public string Status { get; set; }

        [Display(Name = "Profil-Bild")]
        public byte[] Profilepicture { get; set; }

        [Display(Name = "Geburtsdatum")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Straße/Hausnr.")]
        public string Adress { get; set; }

        [Display(Name = "PLZ"), MaxLength(8)]
        public string ZipCode { get; set; }

        [Display(Name = "Wohnort")]
        public string Location { get; set; }

        [Display(Name = "Anstellungsdatum")]
        public DateTime? HiringDate { get; set; }

        [Display(Name = "Telefonnummer")]
        public string Phonenumber { get; set; }

        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}
