namespace Application.Service.PersistenceDb.Interfaces;

using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICrudService<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
