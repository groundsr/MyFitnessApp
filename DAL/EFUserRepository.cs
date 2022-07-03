using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;
using System;
using System.Linq;

namespace MyFitnessApp.DAL
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        private FitnessContext _context;

        public EFUserRepository(FitnessContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public void SetCurrentWeight(int weight, int userId)
        {
            var flag = false;

            var user = _context.Users.Find(userId);
            var userProgress = new UserProgress();
            userProgress.CurrentWeight = weight;
            userProgress.User = user;
            userProgress.WeightLogDate = System.DateTime.Today;
            foreach (var userPrg in _context.UserProgress)
            {
                if (userPrg.WeightLogDate.Month == userProgress.WeightLogDate.Month && userPrg.User.Id == userId)
                {
                    userPrg.CurrentWeight = userProgress.CurrentWeight;
                    flag = true;
                }

            }
            if (!flag)
            {
                _context.UserProgress.Add(userProgress);
            }
            var bmi = (double)userProgress.CurrentWeight / ((user.Height / 100) * (user.Height / 100));
            var twoDecBmi = Math.Round(bmi, 2);
            user.Bmi = twoDecBmi;
            _context.SaveChanges();

        }
    }
}
