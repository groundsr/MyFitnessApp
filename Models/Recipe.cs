using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

    }
}
