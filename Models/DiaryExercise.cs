using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFitnessApp.Models
{
    public class DiaryExercise
    {
        public int DiaryId { get; set; }
        public int ExerciseId { get; set; }
        public virtual Diary Diary { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int HowLong { get; set; }
    }
}
