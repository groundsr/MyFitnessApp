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
            diaryToUpdate.Meals = diary.Meals;
            diaryToUpdate.TotalCalories = diary.TotalCalories;
            _diaryRepository.Update(diaryToUpdate);
        }
        public void Delete(int id)
        {
            _diaryRepository.Remove(id);
        }
    }
}
