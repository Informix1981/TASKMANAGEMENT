namespace Application.Service.PersistenceDb.Implementation;
using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using FluentValidation;

public class AssignmentService : CrudService<Assignment>, IAssignmentService
{
    public AssignmentService(IGenericRepository<Assignment> repository, IValidator<Assignment> validator)
        : base(repository, validator)
    {
    }
}