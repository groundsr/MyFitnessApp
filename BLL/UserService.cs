﻿using MyFitnessApp.DAL;
using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Models;
using System;
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
        public void SetCurrentWeight(int weight, int id)
        {
            _efUserRepository.SetCurrentWeight(weight, id);
        }
        public void Create(User user)
        {
            var bmi = user.Weight / ((user.Height / 100) * (user.Height / 100));
            var twoDecBmi = Math.Round(bmi, 2);
            user.Bmi = twoDecBmi;
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
