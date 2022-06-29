using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Lunch
    {
        public int Id { get; set; }
        public virtual List<LunchMeal> LunchMeals { get; set; }
        public int Calories { get; set; }
    }
}
