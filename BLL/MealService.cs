using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;


namespace MyFitnessApp.BLL
{
    public class MealService
    {
        private readonly IMealRepository _mealRepository;
        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }
        public IEnumerable<Meal> GetAll()
        {
            return _mealRepository.GetAll();
        }
        public Meal Get(int id)
        {
            return _mealRepository.Get(id);
        }
        public void Create(Meal meal)
        {
            _mealRepository.Add(meal);
        }
        public void Update(Meal meal)
        {
            var mealToUpdate = _mealRepository.Get(meal.Id);

            mealToUpdate.Fat = meal.Fat;
            mealToUpdate.Protein = meal.Protein;
            mealToUpdate.Carbohydrates = meal.Carbohydrates;
            mealToUpdate.Calories = meal.Calories;
            mealToUpdate.Name = meal.Name;
            _mealRepository.Update(mealToUpdate);
        }
        public void Delete(int id)
        {
            _mealRepository.Remove(id);
        }
    }
}
