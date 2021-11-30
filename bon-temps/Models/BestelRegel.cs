using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class BestelRegel
    {
        [ForeignKey("Reservering")]
        public int ReserveringId { get; set; }
        public Reservering Reservering { get; set; }
        [ForeignKey("Drank")]
        public int DrankId { get; set; }
        public Drank Drank { get; set; }
        public int Aantal { get; set; }
    }
}
