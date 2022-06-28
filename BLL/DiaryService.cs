using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFitnessApp.BLL
{
    public class DiaryService
    {
        private readonly IDiaryRepository _diaryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IBreakfastMealRepository _breakfastMealRepository;
        private readonly ILunchMealRepository _lunchMealRepository;
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly IDinnerMealRepository _dinnerMealRepository;
        private readonly IBreakfastRepository _breakfastRepository;
        private readonly ILunchRepository _lunchRepository;
        private readonly IDinnerRepository _dinnerRepository;

        public DiaryService(IDiaryRepository diaryRepository, IUserRepository userRepository, IMealRepository mealRepository,
            IBreakfastMealRepository breakfastMealRepository, ILunchMealRepository lunchMealRepository, IDinnerMealRepository dinnerMealRepository
            , IUserPlanRepository userPlanRepository, IBreakfastRepository breakfastRepository
            , ILunchRepository lunchRepository, IDinnerRepository dinnerRepository)
        {
            _diaryRepository = diaryRepository;
            _userRepository = userRepository;
            _mealRepository = mealRepository;
            _breakfastMealRepository = breakfastMealRepository;
            _lunchMealRepository = lunchMealRepository;
            _dinnerMealRepository = dinnerMealRepository;
            _userPlanRepository = userPlanRepository;
            _breakfastRepository = breakfastRepository;
            _lunchRepository = lunchRepository;
            _dinnerRepository = dinnerRepository;
        }
        public IEnumerable<Diary> GetAll()
        {
            return _diaryRepository.GetAll();
        }
        public Diary GetDiaryForUser(int userId)
        {
            return _diaryRepository.GetAll().Last(x => x.Id == userId);
        }

        public IEnumerable<Diary> GetAllDiariesForUser(int userId)
        {
            return _diaryRepository.GetAll();
        }

        public void AddFoodToDiary(int userId, string MealType, int mealId, int quantity)
        {
            var diaries = GetAllDiariesForUser(userId);
            var totalCalories = _userRepository.Get(userId).UserGoal.UserPlan.TotalCalories;
            var latestBreakfast = _breakfastRepository.GetAll().Last();
            var latestLunch = _lunchRepository.GetAll().Last();
            var latestDinner = _dinnerRepository.GetAll().Last();
            var breakfast = new Breakfast();
            var lunch = new Lunch();
            var dinner = new Dinner();
            var newDiary = new Diary();
            newDiary.CreationDate = DateTime.Today;


            if (diaries.Last().CreationDate.Day != DateTime.Today.Day)
            {
                newDiary.User = _userRepository.Get(userId);
                newDiary.TotalCalories = totalCalories;
                newDiary.Breakfast = breakfast;
                newDiary.Lunch = lunch;
                newDiary.Dinner = dinner;
                _diaryRepository.Add(newDiary);
                _diaryRepository.Save();
                if (MealType == "Breakfast")
                {
                    var breakfastMeal = new BreakfastMeal();
                    breakfastMeal.Quantity = quantity;
                    breakfastMeal.MealId = mealId;
                    breakfastMeal.BreakfastId = breakfast.Id;
                    _breakfastMealRepository.Add(breakfastMeal);
                    _breakfastMealRepository.Save();
                }
                else if (MealType == "Lunch")
                {
                    var lunchMeal = new LunchMeal();
                    lunchMeal.Quantity = quantity;
                    lunchMeal.MealId = mealId;
                    lunchMeal.LunchId = lunch.Id;
                    _lunchMealRepository.Add(lunchMeal);
                    _lunchMealRepository.Save();
                }
                else if (MealType == "Dinner")
                {
                    var dinnerMeal = new DinnerMeal();
                    dinnerMeal.Quantity = quantity;
                    dinnerMeal.MealId = mealId;
                    dinnerMeal.DinnerId = dinner.Id;
                    _dinnerMealRepository.Add(dinnerMeal);
                    _dinnerMealRepository.Save();
                }
            }
            else
            if (MealType == "Breakfast")
            {
                var breakfastMeal = new BreakfastMeal();
                breakfastMeal.Quantity = quantity;
                breakfastMeal.MealId = mealId;
                breakfastMeal.BreakfastId = latestBreakfast.Id;
                _breakfastMealRepository.Add(breakfastMeal);
                _breakfastMealRepository.Save();
            }
            else if (MealType == "Lunch")
            {
                var lunchMeal = new LunchMeal();
                lunchMeal.Quantity = quantity;
                lunchMeal.MealId = mealId;
                lunchMeal.LunchId = latestLunch.Id;
                _lunchMealRepository.Add(lunchMeal);
                _lunchMealRepository.Save();
            }
            else if (MealType == "Dinner")
            {
                var dinnerMeal = new DinnerMeal();
                dinnerMeal.Quantity = quantity;
                dinnerMeal.MealId = mealId;
                dinnerMeal.DinnerId = latestDinner.Id;
                _dinnerMealRepository.Add(dinnerMeal);
                _dinnerMealRepository.Save();
            }
        }
        public Diary Get(int id)
        {
            return _diaryRepository.Get(id);
        }
        public void Create(Diary diary)
        {
            diary.CreationDate = System.DateTime.Today;
            _diaryRepository.Add(diary);
        }
        public void Update(Diary diary)
        {
            var diaryToUpdate = _diaryRepository.Get(diary.Id);
            diaryToUpdate.User = diary.User;
            diaryToUpdate.Breakfast = diary.Breakfast;
            diaryToUpdate.Lunch = diary.Lunch;
            diaryToUpdate.Dinner = diary.Dinner;
            diaryToUpdate.TotalCalories = diary.TotalCalories;
            _diaryRepository.Update(diaryToUpdate);
        }
        public void Delete(int id)
        {
            _diaryRepository.Remove(id);
        }
    }
}
