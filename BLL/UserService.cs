using MyFitnessApp.DAL;
using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System.Collections.Generic;


namespace MyFitnessApp.BLL
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EFUserRepository _efUserRepository;

        public UserService(IUserRepository userRepository, EFUserRepository eFUserRepository)
        {
            _userRepository = userRepository;
            _efUserRepository = eFUserRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }
        public User GetByEmail(string email)
        {
            return _efUserRepository.GetByEmail(email);
        }
        public void Create(User user)
        {
            _userRepository.Add(user);
        }
        public void Update(User user)
        {
            var userToUpdate = _userRepository.Get(user.Id);
            userToUpdate.Email = user.Email;
            userToUpdate.Name = user.Name;
            userToUpdate.Password = user.Password;
            _userRepository.Update(userToUpdate);

        }
        public void Delete(int id)
        {
            _userRepository.Remove(id);
        }
    }
}
