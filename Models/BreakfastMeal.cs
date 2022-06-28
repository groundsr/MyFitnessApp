using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFitnessApp.Models
{
    public class BreakfastMeal
    {
        public int BreakfastId { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Breakfast Breakfast { get; set; }
        public int Quantity { get; set; }
    }
}
