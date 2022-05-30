using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFUserPlanRepository : EFRepository<UserPlan>, IUserPlanRepository
    {
        private FitnessContext _context;

        public EFUserPlanRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
