using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;

namespace MyFitnessApp.DAL
{
    public class EFExerciseRepository : EFRepository<Exercise>, IExerciseRepository
    {
        private FitnessContext _context;

        public EFExerciseRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }
    }
}
