using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyFitnessApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<UserProgress> UserProgresses { get; set; }
        public virtual UserGoal UserGoal { get; set; }
        public virtual ICollection<Diary> Diaries { get; set; }


    }
}
