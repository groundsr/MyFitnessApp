using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;
using System.Linq;

namespace MyFitnessApp.DAL
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private FitnessContext _context;

        public EFUserRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
