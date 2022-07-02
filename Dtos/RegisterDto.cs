using MyFitnessApp.Models;
using System;

namespace MyFitnessApp.Dtos
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public UserGoal UserGoal { get; set; }
        public int UserGoalId { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

    }
}
