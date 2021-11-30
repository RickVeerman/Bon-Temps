using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MenuSoort")]
        public int MenuSoortId { get; set; }
        public MenuSoort MenuSoort { get; set; }
        public string Naam { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Prijs { get; set; }
    }
}
