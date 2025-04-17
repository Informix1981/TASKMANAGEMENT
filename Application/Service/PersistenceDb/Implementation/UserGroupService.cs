namespace Application.Service.PersistenceDb.Implementation;

using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using FluentValidation;

public class UserGroupService(IGenericRepository<UserGroup> repository, IValidator<UserGroup> validator) : CrudService<UserGroup>(repository, validator), IUserGroupService
{
}