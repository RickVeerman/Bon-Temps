using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class Vegetarisch
    {
        [Key]
        public int Id { get; set; }
        public string Soort { get; set; }
    }
}
