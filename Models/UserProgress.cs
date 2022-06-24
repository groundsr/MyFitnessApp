using System;

namespace MyFitnessApp.Models
{
    public class UserProgress
    {
        public int Id { get; set; }
        public int CurrentWeight { get; set; }
        public DateTime WeightLogDate { get; set; }
        public virtual User User { get; set; }
    }
}
