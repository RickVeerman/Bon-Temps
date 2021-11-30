using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class Allergie
    {
        [Key]
        public int Id { get; set; }
        public string Allergeen { get; set; }
    }
}
