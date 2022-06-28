using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFBreakfastRepository : EFRepository<Breakfast>, IBreakfastRepository
    {
        private FitnessContext _context;

        public EFBreakfastRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
