using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class Drank
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DrankSoort")]
        public int DrankSoortId { get; set; }
        public DrankSoort DrankSoort { get; set; }
        public string Naam { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Prijs { get; set; }


    }
}
