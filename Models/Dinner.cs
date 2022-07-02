using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Dinner
    {
        public int Id { get; set; }
        public virtual List<DinnerMeal> DinnerMeals { get; set; }
        public int Calories { get; set; }
        public int TotalProtein { get; set; }
        public int TotalFat { get; set; }
        public int TotalCarbohydrates { get; set; }

    }
}
