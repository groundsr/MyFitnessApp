using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }
        public virtual ICollection<Dinner> Dinners { get; set; }
        //public virtual ICollection<Breakfast> Breakfasts { get; set; }
        public virtual ICollection<Lunch> Lunches { get; set; }
        public virtual List<BreakfastMeal> BreakfastMeals { get; set; }
        public virtual List<LunchMeal> LunchMeals { get; set; }
        public virtual List<DinnerMeal> DinnerMeals { get; set; }
    }

}
