using System;

namespace MyFitnessApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public virtual UserGoal UserGoal { get; set; }


    }
}
