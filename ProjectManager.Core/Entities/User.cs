using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManager.Core.Entities
{
    public class User : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "User-Name wird benötigt")]
        [MinLength(5, ErrorMessage = "Die Mindestlänge beträgt 5 Buchstaben")]
        [MaxLength(15, ErrorMessage = "Die maximale Läge beträgt 15 Buchstaben")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Code zum zurücksetzen des Passworts")]
        public string PasswordCode { get; set; }

        [Display(Name = "Administrator")]
        //[Authorize(Roles = "Administrator")]
        public bool Admin { get; set; }
    }
}
