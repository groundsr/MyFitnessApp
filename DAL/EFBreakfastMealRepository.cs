using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFBreakfastMealRepository : EFRepository<BreakfastMeal>, IBreakfastMealRepository
    {
        private FitnessContext _context;

        public EFBreakfastMealRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
