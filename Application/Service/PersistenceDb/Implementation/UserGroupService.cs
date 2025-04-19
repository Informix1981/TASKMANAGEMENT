namespace Application.Service.PersistenceDb.Implementation;

using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using FluentValidation;

public class UserGroupService(IGenericRepository<UserGroup,int> repository, IValidator<UserGroup> validator) : CrudService<UserGroup, int>(repository, validator), IUserGroupService
{
}