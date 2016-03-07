using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooxi.Models
{ 
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public string MeasureUnit { get; set; }
        public float Count { get; set; }
        public ICollection<Recipe> Recipe { get; set; }
    }
}
