using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFDiaryRepository : EFRepository<Diary>, IDiaryRepository
    {
        private FitnessContext _context;

        public EFDiaryRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
