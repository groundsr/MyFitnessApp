﻿using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //return  _diaryRepository.GetAll().Last(x => x.Id == userId);
            return _diaryRepository.GetAll().FirstOrDefault(x => x.User.Id == userId && x.CreationDate.Day == DateTime.Today.Day);
        }

        public IEnumerable<Diary> GetAllDiariesForUser(int userId)
        {
            return _diaryRepository.GetAll().Where(x => x.User.Id == userId);
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
            var meal = _mealRepository.Get(mealId);


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
                    breakfastMeal.ActualCalories = (int)((double)quantity / 100 * meal.Calories);
                    breakfastMeal.ActualProtein = (float)Math.Round((float)quantity / 100 * meal.Protein, 1);
                    breakfastMeal.ActualCarbs = (float)Math.Round((float)quantity / 100 * meal.Carbohydrates, 1);
                    breakfastMeal.ActualFat = (float)Math.Round((float)quantity / 100 * meal.Fat, 1);
                    breakfastMeal.Quantity = quantity;
                    breakfastMeal.MealId = mealId;
                    breakfast.Calories += breakfastMeal.ActualCalories;
                    _breakfastRepository.GetAll().Last().Calories += breakfastMeal.ActualCalories;
                    _breakfastMealRepository.Add(breakfastMeal);
                    _breakfastMealRepository.Save();
                    _breakfastRepository.Save();
                    _breakfastRepository.Save();
                }
                else if (MealType == "Lunch")
                {
                    var lunchMeal = new LunchMeal();
                    lunchMeal.ActualCalories = (int)((double)quantity / 100 * meal.Calories);
                    lunchMeal.ActualProtein = (float)Math.Round((float)quantity / 100 * meal.Protein, 1);
                    lunchMeal.ActualCarbs = (float)Math.Round((float)quantity / 100 * meal.Carbohydrates, 1);
                    lunchMeal.ActualFat = (float)Math.Round((float)quantity / 100 * meal.Fat, 1);
                    lunchMeal.Quantity = quantity;
                    lunchMeal.MealId = mealId;
                    lunchMeal.LunchId = lunch.Id;
                    _lunchRepository.GetAll().Last().Calories += lunchMeal.ActualCalories;
                    _lunchMealRepository.Add(lunchMeal);
                    _lunchMealRepository.Save();
                    _lunchRepository.Save();
                }
                else if (MealType == "Dinner")
                {
                    var dinnerMeal = new DinnerMeal();
                    dinnerMeal.ActualCalories = (int)((double)quantity / 100 * meal.Calories);
                    dinnerMeal.ActualProtein = (float)Math.Round((float)quantity / 100 * meal.Protein, 1);
                    dinnerMeal.ActualCarbs = (float)Math.Round((float)quantity / 100 * meal.Carbohydrates, 1);
                    dinnerMeal.ActualFat = (float)Math.Round((float)quantity / 100 * meal.Fat, 1);
                    dinnerMeal.Quantity = quantity;
                    dinnerMeal.MealId = mealId;
                    dinnerMeal.DinnerId = dinner.Id;
                    _dinnerRepository.GetAll().Last().Calories += dinnerMeal.ActualCalories;
                    _dinnerMealRepository.Add(dinnerMeal);
                    _dinnerMealRepository.Save();
                    _dinnerRepository.Save();
                }
            }
            else
            if (MealType == "Breakfast")
            {
                var breakfastMeal = new BreakfastMeal();
                breakfastMeal.ActualCalories = (int)((double)quantity / 100 * meal.Calories);
                breakfastMeal.ActualProtein = (float)Math.Round((float)quantity / 100 * meal.Protein, 1);
                breakfastMeal.ActualCarbs = (float)Math.Round((float)quantity / 100 * meal.Carbohydrates, 1);
                breakfastMeal.ActualFat = (float)Math.Round((float)quantity / 100 * meal.Fat, 1);
                breakfastMeal.Quantity = quantity;
                breakfastMeal.MealId = mealId;
                breakfastMeal.BreakfastId = latestBreakfast.Id;
                _breakfastRepository.GetAll().Last().Calories += breakfastMeal.ActualCalories;
                _breakfastMealRepository.Add(breakfastMeal);
                _breakfastMealRepository.Save();
                _breakfastRepository.Save();
            }
            else if (MealType == "Lunch")
            {
                var lunchMeal = new LunchMeal();
                lunchMeal.ActualCalories = (int)((double)quantity / 100 * meal.Calories);
                lunchMeal.ActualProtein = (float)Math.Round((float)quantity / 100 * meal.Protein, 1);
                lunchMeal.ActualCarbs = (float)Math.Round((float)quantity / 100 * meal.Carbohydrates, 1);
                lunchMeal.ActualFat = (float)Math.Round((float)quantity / 100 * meal.Fat, 1);
                lunchMeal.Quantity = quantity;
                lunchMeal.MealId = mealId;
                lunchMeal.LunchId = latestLunch.Id;
                _lunchRepository.GetAll().Last().Calories += lunchMeal.ActualCalories;
                _lunchMealRepository.Add(lunchMeal);
                _lunchMealRepository.Save();
                _lunchRepository.Save();
            }
            else if (MealType == "Dinner")
            {
                var dinnerMeal = new DinnerMeal();
                dinnerMeal.ActualCalories = (int)((double)quantity / 100 * meal.Calories);
                dinnerMeal.ActualProtein = (float)Math.Round((float)quantity / 100 * meal.Protein, 1);
                dinnerMeal.ActualCarbs = (float)Math.Round((float)quantity / 100 * meal.Carbohydrates, 1);
                dinnerMeal.ActualFat = (float)Math.Round((float)quantity / 100 * meal.Fat, 1);
                dinnerMeal.Quantity = quantity;
                dinnerMeal.MealId = mealId;
                dinnerMeal.DinnerId = latestDinner.Id;
                _dinnerRepository.GetAll().Last().Calories += dinnerMeal.ActualCalories;
                _dinnerMealRepository.Add(dinnerMeal);
                _dinnerMealRepository.Save();
                _dinnerRepository.Save();
            }
        }

        public void DeleteFoodFromDiary(int userId, string MealType, int mealId)
        {
            var lastDiary = GetAllDiariesForUser(userId).Last();
            var meal = _mealRepository.Get(mealId);
            if (MealType == "Breakfast")
            {
                var breakfastId = _breakfastMealRepository.GetAll().Last().BreakfastId;
                var breakfastMeal = _breakfastMealRepository.GetComposite(breakfastId, mealId);
                lastDiary.Breakfast.BreakfastMeals.Remove(breakfastMeal);
                _diaryRepository.Save();
            }
            if (MealType == "Lunch")
            {
                var lunchId = _lunchMealRepository.GetAll().Last().LunchId;
                var lunchMeal = _lunchMealRepository.GetComposite(lunchId, mealId);
                lastDiary.Lunch.LunchMeals.Remove(lunchMeal);
                _diaryRepository.Save();
            }
            if (MealType == "Dinner")
            {
                var dinnerId = _dinnerMealRepository.GetAll().Last().DinnerId;
                var dinnerMeal = _dinnerMealRepository.GetComposite(dinnerId, mealId);
                lastDiary.Dinner.DinnerMeals.Remove(dinnerMeal);
                _diaryRepository.Save();
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
