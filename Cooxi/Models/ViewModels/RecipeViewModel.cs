using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cooxi.Models.ViewModels
{
    public class SaveRecipeViewModel
    {
        public string title { get; set; }
        public string prepare { get; set; }
        public string ration { get; set; }
        public string dificulty { get; set; }
        public string type { get; set; }
        public string instagramId { get; set; }
        public List<string> tags { get; set; }
        public List<IngredientsViewModel> ingredients { get; set; }
    }

    public class IngredientsViewModel
    {
        public string name { get; set; }
        public string count { get; set; }
        public string measure { get; set; }
    }
}