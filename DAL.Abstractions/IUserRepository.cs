using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using static MyFitnessApp.DAL.Abstractions.IRepository;

namespace MyFitnessApp.DAL.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {

    }
}
