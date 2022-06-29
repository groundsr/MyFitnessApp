using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Breakfast
    {
        public int Id { get; set; }
        public virtual List<BreakfastMeal> BreakfastMeals { get; set; }
        public int Calories { get; set; }

    }
}
