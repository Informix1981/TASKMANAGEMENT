using FluentValidation;
using Domain.Entities;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(u => u.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => role == "User" || role == "Admin").WithMessage("Role must be either 'User' or 'Admin'.");
        }
    }
}