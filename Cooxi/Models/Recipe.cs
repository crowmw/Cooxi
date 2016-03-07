using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooxi.Models
{
    public class Recipe
    {
        public Recipe()
        {
            IngredientsList = new List<Ingredient>();
        }

        public Guid RecipeId { get; set; }

        public string InstagramId { get; set; }

        public string Title { get; set; }

        public ICollection<Ingredient> IngredientsList { get; set; }

        public string Prepare { get; set; }

        public string Ration { get; set; }

        public string Dificulty { get; set; }

        public string MealType { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
