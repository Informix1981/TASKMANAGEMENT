namespace Application.Service.PersistenceDb.Implementation;
using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using FluentValidation;

public class AssignmentService(IGenericRepository<Assignment,int> repository, IValidator<Assignment> validator) : CrudService<Assignment, int>(repository, validator), IAssignmentService
{
}