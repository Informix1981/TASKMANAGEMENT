namespace Application.Service.PersistenceDb.Implementation;
using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using FluentValidation;

public class AssignmentService(IGenericRepository<Assignment> repository, IValidator<Assignment> validator) : CrudService<Assignment>(repository, validator), IAssignmentService
{
}