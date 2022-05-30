using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;

namespace MyFitnessApp.BLL
{
    public class UserPlanService
    {
        private readonly IUserPlanRepository _userPlanRepository;

        public UserPlanService(IUserPlanRepository userPlanRepository)
        {
            _userPlanRepository = userPlanRepository;
        }
        public IEnumerable<UserPlan> GetAll()
        {
            return _userPlanRepository.GetAll();
        }
        public UserPlan Get(int id)
        {
            return _userPlanRepository.Get(id);
        }
        public void Create(UserPlan userPlan)
        {
            _userPlanRepository.Add(userPlan);
        }
        public void Update(UserPlan userPlan)
        {
            var userPlanToUpdate = _userPlanRepository.Get(userPlan.Id);
            userPlanToUpdate.BMI = userPlan.BMI;
            userPlanToUpdate.TotalProtein = userPlan.TotalProtein;
            userPlanToUpdate.TotalCarbs = userPlan.TotalCarbs;
            userPlanToUpdate.TotalFat = userPlan.TotalFat;
            userPlanToUpdate.TotalCalories = userPlan.TotalCalories;
            userPlanToUpdate.UserGoals = userPlan.UserGoals;
            _userPlanRepository.Update(userPlanToUpdate);

        }
        public void Delete(int id)
        {
            _userPlanRepository.Remove(id);
        }
    }
}
