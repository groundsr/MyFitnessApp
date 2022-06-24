using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EfUserProgressRepository : EFRepository<UserProgress>, IUserProgressRepository
    {
        private FitnessContext _context;

        public EfUserProgressRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
