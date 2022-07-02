using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyFitnessApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [JsonIgnore]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Weight { get; set; }
        public double Bmi
        {
            get; set;
        }
        public virtual ICollection<UserProgress> UserProgresses { get; set; }
        public virtual UserGoal UserGoal { get; set; }
        public int UserGoalId { get; set; }
        public virtual ICollection<Diary> Diaries { get; set; }


    }
}
