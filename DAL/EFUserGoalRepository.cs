using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFUserGoalRepository : EFRepository<UserGoal>, IUserGoalRepository
    {
        private FitnessContext _context;

        public EFUserGoalRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
