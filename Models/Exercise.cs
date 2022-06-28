using System.Collections.Generic;

namespace MyFitnessApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Diary> Diaries { get; set; }
        public virtual List<DiaryExercise> DiaryExercises { get; set; } 

    }
}
