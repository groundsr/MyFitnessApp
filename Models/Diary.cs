using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Diary
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<Meal> Meals { get; set; }
        public int TotalCalories { get; set; }

    }
}
