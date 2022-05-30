using Microsoft.EntityFrameworkCore;
using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFitnessApp.DAL
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private FitnessContext _context;

        public EFUserRepository(FitnessContext context): base(context)
        {
            _context = context;
        }
    }
}
