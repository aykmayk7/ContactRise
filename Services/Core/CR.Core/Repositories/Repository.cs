using CR.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CR.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly BaseContext Context;

        public Repository(BaseContext context)
        {
            Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            Context.Set<T>().Add(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var current = Context.Entry(entity).CurrentValues.Clone();

            Context.Entry(entity).Reload();

            _ = Context.Entry(entity).CurrentValues.Clone().ToObject();

            Context.Entry(entity).CurrentValues.SetValues(current);

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return entity;

        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, IList<string> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool disableTracking = true)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete);

            if (disableTracking) query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            string sql = query.ToQueryString();

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, IList<string> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool disableTracking = true)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete);

            if (disableTracking) query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllPagedAsync(Expression<Func<T, bool>> predicate, int PageNumber, int PageSize, IList<string> includes = null)
        {
            IQueryable<T> query = Context.Set<T>().Where(a => !a.IsDelete);

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            var totalRecords = await query.CountAsync();

            var pagedData = await query
                 .Skip((PageNumber - 1) * PageSize).Take(PageSize)
                 .ToListAsync();

            var sql = query.ToQueryString();

            return await query.ToListAsync();
        }
    }
}
