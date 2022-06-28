using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFDinnerRepository : EFRepository<Dinner>, IDinnerRepository
    {
        private FitnessContext _context;

        public EFDinnerRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
