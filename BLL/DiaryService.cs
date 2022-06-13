using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFitnessApp.BLL
{
    public class DiaryService
    {
        private readonly IDiaryRepository _diaryRepository;
        private readonly IUserRepository _userRepository;

        public DiaryService(IDiaryRepository diaryRepository, IUserRepository userRepository)
        {
            _diaryRepository = diaryRepository;
            _userRepository = userRepository;
        }
        public IEnumerable<Diary> GetAll()
        {
            return _diaryRepository.GetAll();
        }
        public Diary GetDiaryForUser(int userId)
        {
            return _diaryRepository.GetAll().FirstOrDefault(x => x.User.Id == userId);
        }

        public void AddFoodToDiary(int userId, string MealType, Meal meal)
        {
            var diary = GetDiaryForUser(userId);
            if(MealType == "Breakfast")
            {
                diary.Breakfast.Meals.Add(meal);
            }
            else if (MealType == "Lunch")
            {
                diary.Lunch.Meals.Add(meal);
            }
            else
            {
                diary.Dinner.Meals.Add(meal);
            }
        }
        public Diary Get(int id)
        {
            return _diaryRepository.Get(id);
        }
        public void Create(Diary diary)
        {
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
