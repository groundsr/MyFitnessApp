using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Dinner
    {
        public int Id { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public int Calories { get; set; }

    }
}
