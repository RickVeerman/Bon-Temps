using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bon_temps.Models
{
    /// <summary>
    /// This class is a model for all application Users.
    /// The diffeerence between Employees and Customers is implemented in Roles.
    /// <seealso cref="IdentityUser"/>
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Voornaaam")]
        [StringLength(40)]
        public string Voornaam { get; set; }

        [StringLength(20)]
        public string Tussenvoegsel { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        [StringLength(80)]
        public string Achternaam { get; set; }
        public string Woonplaats { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        [Display(Name = "Hele Naam")]
        public string HeleNaam => $"{Voornaam} {Tussenvoegsel} {Achternaam}";
    }
}
