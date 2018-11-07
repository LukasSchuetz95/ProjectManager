using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Qualification : EntityObject
    {

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Qualifikation")]
        public string QualificationName { get; set; }
    }
}
