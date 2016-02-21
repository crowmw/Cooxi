using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooxi.Models
{
    public enum MealType
    {
        Śniadanie,
        Lunch,
        Przystawka,
        Obiad,
        Deser,
        Podwieczorek,
        Kolacja,
        Przekąska
    }

    public enum Difficulty
    {
        Łatwe,
        Średnie,
        Trudne
    }

    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
        [Required]
        public Guid RecipeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string PrepareDescription { get; set; }
        [Required]
        public ICollection<Ingredient> Ingredients { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public string Note { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        [Required]
        public string ServingFor { get; set; }
        [Required]
        public Difficulty Difficulty { get; set; }
        [Required]
        public MealType MealType { get; set; }
        
    }
}
