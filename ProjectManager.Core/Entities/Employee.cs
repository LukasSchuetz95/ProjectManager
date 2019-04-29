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

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "Job")]
        public string Job { get; set; }

        public EmployeeStatusType Status { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[] Profilepicture { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Street address")]
        public string StreetNameAndNr { get; set; }

        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }

        [Display(Name = "Town/City")]
        public string Residence { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime? HiringDate { get; set; }

        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }

        
    }
}
