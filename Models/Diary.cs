﻿namespace MyFitnessApp.Models
{
    public class Diary
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Meal Meal { get; set; }
        public int TotalCalories { get; set; }

    }
}