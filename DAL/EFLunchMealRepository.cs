using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFLunchMealRepository : EFRepository<LunchMeal>, ILunchMealRepository
    {
        private FitnessContext _context;

        public EFLunchMealRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
