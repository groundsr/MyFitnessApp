using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFLunchRepository : EFRepository<Lunch>, ILunchRepository
    {
        private FitnessContext _context;

        public EFLunchRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
