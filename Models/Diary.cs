using System;
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
#nullable enable
        public virtual ICollection<Exercise>? Exercises { get; set; }
        public virtual List<DiaryExercise> DiaryExercises { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalCalories { get; set; }

    }
}
