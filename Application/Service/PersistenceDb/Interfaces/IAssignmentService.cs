using Domain.Entities;

namespace Application.Service.PersistenceDb.Interfaces;
public interface IAssignmentService
{
    Task<Assignment> CreateAsync(Assignment entity);
    Task<Assignment> GetByIdAsync(int id);
    Task<IEnumerable<Assignment>> GetAllAsync();
    Task UpdateAsync(Assignment entity);
    Task DeleteAsync(int id);
}