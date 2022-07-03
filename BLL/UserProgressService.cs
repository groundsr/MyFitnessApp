using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;

namespace MyFitnessApp.BLL
{
    public class UserProgressService
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public UserProgressService(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }
        public IEnumerable<UserProgress> GetAll()
        {
            return _userProgressRepository.GetAll();
        }
        public UserProgress Get(int id)
        {
            return _userProgressRepository.Get(id);
        }
        public void Create(UserProgress userProgress)
        {
            _userProgressRepository.Add(userProgress);
        }
        public void Save()
        {
            _userProgressRepository.Save();
        }
        public void Update(UserProgress userProgress)
        {
            var userProgressToUpdate = _userProgressRepository.Get(userProgress.Id);
            userProgressToUpdate.CurrentWeight = userProgress.CurrentWeight;
            userProgress.WeightLogDate = userProgress.WeightLogDate;
            _userProgressRepository.Update(userProgressToUpdate);

        }
        public void Delete(int id)
        {
            _userProgressRepository.Remove(id);
        }
    }
}
