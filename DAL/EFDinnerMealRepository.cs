using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFDinnerMealRepository : EFRepository<DinnerMeal>, IDinnerMealRepository
    {
        private FitnessContext _context;

        public EFDinnerMealRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
