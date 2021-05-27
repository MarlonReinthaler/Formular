using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Formular.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[\w ._-]*$", ErrorMessage = "Kein gültiger Name")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Der Name darf nicht mehr als 200 Zeichen beeinhalten")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ort")]
        [RegularExpression(@"^[\w ]*$", ErrorMessage = "Kein gültiger Ort")]
        public string Ort { get; set; }

        [Required]
        [Display(Name = "PLZ")]
        [RegularExpression(@"^(\d{5})*$", ErrorMessage = "Keine gültige PLZ")]
        public string PLZ { get; set; }

        [Required]
        [Display(Name = "Alter")]
        [RegularExpression(@"^(\d{2})*$", ErrorMessage = "Keine gültiges Alter")]
        public string PAlter { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }
    }
}
