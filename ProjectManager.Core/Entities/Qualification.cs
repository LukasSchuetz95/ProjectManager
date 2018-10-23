using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Qualification : EntityObject
    {
        public List<EmployeeQualification> EmployeeQualifications { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Qualifikation")]
        public string QualificationName { get; set; }
    }
}
