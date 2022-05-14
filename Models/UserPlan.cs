using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class UserPlan
    {
        public int Id { get; set; }
        public virtual IEnumerable<UserGoal> UserGoals { get; set; }
        public int BMI { get; set; }
        public int TotalCalories { get; set; }
        public int TotalCarbs { get; set; }
        public int TotalProtein { get; set; }
        public int TotalFat { get; set; }
        public enum UserPlanType { gain, maintain, cut }
    }
}
