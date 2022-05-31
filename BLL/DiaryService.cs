using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;


namespace MyFitnessApp.BLL
{
    public class DiaryService
    {
        private readonly IDiaryRepository _diaryRepository;

        public DiaryService(IDiaryRepository diaryRepository)
        {
            _diaryRepository = diaryRepository;
        }
        public IEnumerable<Diary> GetAll()
        {
            return _diaryRepository.GetAll();
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
