﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFitnessApp.Models
{
    public class LunchMeal
    {
        public int LunchId { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Lunch Lunch { get; set; }
        public int ActualCalories { get; set; }
        public float ActualFat { get; set; }
        public float ActualCarbs { get; set; }
        public float ActualProtein { get; set; }
        public int Quantity { get; set; }
    }
}
