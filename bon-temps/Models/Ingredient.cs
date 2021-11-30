using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bon_temps.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Eenheid { get; set; }
        [ForeignKey("Vegetarisch")]
        public int VegetarischId { get; set; }
        public Vegetarisch Vegetarisch { get; set; }
        [ForeignKey("Allergie")]
        public int AllergieId { get; set; }
        public Allergie Allergie { get; set; }
    }
}
