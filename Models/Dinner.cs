using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Dinner
    {
        public int Id { get; set; }
        public virtual List<DinnerMeal> DinnerMeals { get; set; }
        public int Calories { get; set; }

    }
}
