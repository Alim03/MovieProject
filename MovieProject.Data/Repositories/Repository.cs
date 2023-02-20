using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Data.Context;
using MovieProject.Domain.Interfaces;

namespace MovieProject.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MovieProjectDbContext Context;
        protected DbSet<T> entities;

        public Repository(MovieProjectDbContext context)
        {
            Context = context;
            entities = Context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await entities.Where(filter).ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await entities.SingleOrDefaultAsync(filter);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            entities.Update(entity);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
