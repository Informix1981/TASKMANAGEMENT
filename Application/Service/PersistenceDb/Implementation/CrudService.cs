namespace Application.Service.PersistenceDb.Implementation;

using Application.Service.PersistenceDb.Interfaces;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class CrudService<T> : ICrudService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;
    private readonly IValidator<T> _validator;

    protected CrudService(IGenericRepository<T> repository, IValidator<T> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<T> CreateAsync(T entity)
    {
        var validationResult = await _validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        await _repository.AddAsync(entity);
        return entity;
    }

    public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task UpdateAsync(T entity)
    {
        var validationResult = await _validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
