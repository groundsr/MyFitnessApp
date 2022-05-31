﻿using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private FitnessContext _context;

        public EFUserRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
