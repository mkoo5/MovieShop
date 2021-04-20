using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;



        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }



        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }



        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }



        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }



            return await _dbContext.Set<T>().CountAsync();
        }



        public virtual async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return false;
            }



            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }



        public virtual async Task<T> AddAsync(T entity)
        {
            // Movie - Id, title, revenue, budget , 55
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        public virtual async Task<T> UpdateAsync(T entity)
        {
            // Disconnted way of doing things
            // Movie - Id, title, revenue, budget, 55
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        // example input is in userservice; where is a boolean expression like 
        // p => p.UserId == _currentUserService.UserId,
        // includes is a list of objects like p => p.Movie
        // params means it takes a variable amount of arguments
        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> @where, 
            params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return await query.Where(@where).ToListAsync();
        }
    }
}
