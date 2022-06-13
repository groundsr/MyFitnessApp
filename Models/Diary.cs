using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Diary
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Breakfast Breakfast { get; set; }
        public virtual Lunch Lunch { get; set; }
        public virtual Dinner Dinner { get; set; }
        public int TotalCalories { get; set; }

    }
}
