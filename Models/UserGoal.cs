using System.Collections;
using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public enum UserActivity
    {
        VeryActive=0,
        Active=1,
        NotSoActive=2,
        Sedentary=3,
    }
    public enum Goal
    {
        Maintain=0,
        Gain=1,
        Cut=2
    }
    public class UserGoal
    {
        public int Id { get; set; }
        public IEnumerable<User> Users { get; set; }
        public Goal Goal { get; set; }
        public int GoalWeight { get; set; }
        public float GoalPerWeek { get; set; }
        public UserActivity UserActivity { get; set; }
        public virtual UserPlan UserPlan { get; set; }
    }
}
