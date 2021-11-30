using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class GerechtIngredient
    {
        [ForeignKey("Gerecht")]
        public int GerechtId { get; set; }
        public Gerecht Gerecht { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Aantal { get; set; }
    }
}
