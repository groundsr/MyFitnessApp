using Microsoft.EntityFrameworkCore;
using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static MyFitnessApp.DAL.Abstractions.IRepository;

namespace MyFitnessApp.DAL
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly FitnessContext context;
        private readonly DbSet<T> dbSet;

        public EFRepository(FitnessContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        
        public void Save()
        {
            context.SaveChanges();              
        }
        public void Add(T entity)
        {
            context.Add(entity);
            Save();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public T GetComposite(int id1, int id2)
        {
            return dbSet.Find(id1, id2);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public void Remove(int id)
        {
            dbSet.Remove(Get(id));
            Save();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            Save();
        }
    }
}
