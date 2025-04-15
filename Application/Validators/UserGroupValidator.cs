using FluentValidation;
using Domain.Entities;

namespace Application.Validators
{
    public class UserGroupValidator : AbstractValidator<UserGroup>
    {
        public UserGroupValidator()
        {
            RuleFor(ug => ug.Name)
                .NotEmpty().WithMessage("Group Name is required.");

            RuleForEach(ug => ug.Users)
                .NotNull().WithMessage("User in the group cannot be null.");
        }
    }
}