using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnboardingSIGDB1.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext = null;
        protected DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> funcFilter = null)
        {
            if (funcFilter != null)
                return _dbSet.Where(funcFilter);

            return _dbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> funcFilter)
        {
            return _dbSet.FirstOrDefault(funcFilter);
        }

        public bool Exist(Expression<Func<T, bool>> funcFilter)
        {
            return _dbSet.Any(funcFilter);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _dbSet?.Remove(entity);
        }


    }
}
