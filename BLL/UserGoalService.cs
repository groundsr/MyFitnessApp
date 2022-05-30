using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;

namespace MyFitnessApp.BLL
{
    public class UserGoalService
    {
        private readonly IUserGoalRepository _userGoalRepository;

        public UserGoalService(IUserGoalRepository userGoalRepository)
        {
            _userGoalRepository = userGoalRepository;
        }
        public IEnumerable<UserGoal> GetAll()
        {
            return _userGoalRepository.GetAll();
        }
        public UserGoal Get(int id)
        {
            return _userGoalRepository.Get(id);
        }
        public void Create(UserGoal userGoal)
        {
            _userGoalRepository.Add(userGoal);
        }
        public void Update(UserGoal userGoal)
        {
            var userGoalToUpdate = _userGoalRepository.Get(userGoal.Id);
            userGoalToUpdate.UserPlan = userGoal.UserPlan;
            userGoalToUpdate.Users = userGoal.Users;
            userGoalToUpdate.UserActivity = userGoal.UserActivity;
            userGoalToUpdate.GoalPerWeek = userGoal.GoalPerWeek;
            userGoalToUpdate.Goal = userGoal.Goal;
            userGoalToUpdate.GoalWeight = userGoal.GoalWeight;
            _userGoalRepository.Update(userGoalToUpdate);

        }
        public void Delete(int id)
        {
            _userGoalRepository.Remove(id);
        }
    }
}
