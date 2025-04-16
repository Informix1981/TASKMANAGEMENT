namespace Application.Service.PersistenceDb.Implementation;

using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using FluentValidation;

public class UserGroupService : CrudService<UserGroup>, IUserGroupService
{
    public UserGroupService(IGenericRepository<UserGroup> repository, IValidator<UserGroup> validator)
        : base(repository, validator)
    {
    }
}