using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;


namespace MyFitnessApp.BLL
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public IEnumerable<Exercise> GetAll()
        {
            return _exerciseRepository.GetAll();
        }
        public Exercise Get(int id)
        {
            return _exerciseRepository.Get(id);
        }
        public void Create(Exercise exercise)
        {
            _exerciseRepository.Add(exercise);
        }
        public void Update(Exercise exercise)
        {
            var exerciseToUpdate = _exerciseRepository.Get(exercise.Id);

            exerciseToUpdate.CaloriesBurnt = exercise.CaloriesBurnt;
            exerciseToUpdate.Name = exercise.Name;
            _exerciseRepository.Update(exerciseToUpdate);
        }
        public void Delete(int id)
        {
            _exerciseRepository.Remove(id);
        }
    }
}
