using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class ReserveringMenu
    {
        [ForeignKey("Reservering")]
        public int ReserveringId { get; set; }
        public Reservering Reservering { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int Aantal { get; set; }
    }
}
