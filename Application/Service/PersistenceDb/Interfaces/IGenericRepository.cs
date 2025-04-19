using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Service.PersistenceDb.Interfaces
{
    public interface IGenericRepository<T, TKey> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);
        Task<T> GetByIdAsync(TKey id);
        Task AddAsync(T entity, bool saveChanges = true);
        Task UpdateAsync(T entity, bool saveChanges = true);
        Task DeleteAsync(TKey id, bool saveChanges = true);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
    }
}