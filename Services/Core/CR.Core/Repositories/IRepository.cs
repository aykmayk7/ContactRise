using CR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CR.Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                      IList<string> includes = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      bool disableTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null,
                                      IList<string> includes = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      bool disableTracking = true);

        Task<IEnumerable<T>> GetAllPagedAsync(Expression<Func<T, bool>> predicate, int PageNumber, int PageSize, IList<string> includes = null);

    }
}
