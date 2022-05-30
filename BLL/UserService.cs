using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;


namespace MyFitnessApp.BLL
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }
        public void Create(User user)
        {
            _userRepository.Add(user);
        }
        public void Update(User user)
        {
            var userToUpdate = _userRepository.Get(user.Id);
            userToUpdate.Email = user.Email;
            userToUpdate.Weight = user.Weight;
            userToUpdate.BirthDay = user.BirthDay;
            userToUpdate.Height = user.Height;
            userToUpdate.Name = user.Name;
            userToUpdate.Sex = user.Sex;
            userToUpdate.Password = user.Password;
            userToUpdate.UserGoal = user.UserGoal;
            _userRepository.Update(userToUpdate);

        }
        public void Delete(int id)
        {
            _userRepository.Remove(id);
        }
    }
}
