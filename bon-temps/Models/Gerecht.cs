using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class Gerecht
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("GerechtSoort")]
        public int GerechtSoortId { get; set; }
        public GerechtSoort GerechtSoort { get; set; }
        public string Naam { get; set; }
    }
}
