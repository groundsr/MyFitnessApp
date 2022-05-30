using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyFitnessApp.DAL.Abstractions
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            T Get(int id);
            void Add(T entity);
            void Remove(int id);
            void Update(T entity);
            void Save();
            IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        }
    }
}
