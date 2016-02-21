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
        [Required]
        public Guid IngredientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MeasureUnit MeasureUnit { get; set; }
        public ICollection<Recipe> Recipe { get; set; }
    }
}
