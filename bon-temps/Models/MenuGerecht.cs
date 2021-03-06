using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class MenuGerecht
    {
        [ForeignKey("Gerecht")]
        public int GerechtId { get; set; }
        public Gerecht Gerecht { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
