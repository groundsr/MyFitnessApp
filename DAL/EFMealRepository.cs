using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFMealRepository : EFRepository<Meal>, IMealRepository
    {
        private FitnessContext _context;

        public EFMealRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
