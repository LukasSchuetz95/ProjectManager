using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;
using ProjectManager.Core.Enum;

namespace ProjectManager.Core.Entities
{
    public class Employee : EntityObject
    {
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Vorname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Nachname")]
        public string Lastname { get; set; }

        [Display(Name = "Job-Name")]
        public string Job { get; set; }

        public EmployeeStatusType Status { get; set; }

        [Display(Name = "Profil-Bild")]
        public byte[] Profilepicture { get; set; }

        [Display(Name = "Geburtsdatum")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Straße/Hausnr.")]
        public string StreetNameAndNr { get; set; }

        [Display(Name = "PLZ")]
        public string ZipCode { get; set; }

        [Display(Name = "Wohnort")]
        public string Residence { get; set; }

        [Display(Name = "Anstellungsdatum")]
        public DateTime? HiringDate { get; set; }

        [Display(Name = "Telefonnummer")]
        public string Phonenumber { get; set; }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }
    }
}
