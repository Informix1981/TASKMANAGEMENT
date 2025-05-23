using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;
using Application.Service.PersistenceDb.Interfaces;

namespace Application.Service.PersistenceDb.Implementation
{
    public class UserService(IGenericRepository<User,int> userRepository, IValidator<User> userValidator) : IUserService
    {
        private readonly IGenericRepository<User,int> _userRepository = userRepository;
        private readonly IValidator<User> _userValidator = userValidator;

        public async Task<User> CreateUser(User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task UpdateUser(User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}