using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFitnessApp.Models
{
    public class DinnerMeal
    {
        public int DinnerId { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Dinner Dinner { get; set; }
        public int Quantity { get; set; }
    }
}
