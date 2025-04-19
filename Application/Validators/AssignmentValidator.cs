using FluentValidation;
using Domain.Entities;
using Application.Service.PersistenceDb;
using Application.Service.PersistenceDb.Interfaces;

namespace Application.Validators
{
    public class AssignmentValidator: AbstractValidator<Assignment>
    {
        private readonly IGenericRepository<Assignment, int> _assignmentDb;

        public AssignmentValidator(IGenericRepository<Assignment, int> assignmentDb)
        {
            _assignmentDb = assignmentDb;
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(a => a.StartDate)
                .NotEmpty().WithMessage("Start Date is required.");

            RuleFor(a => a.EndDate)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThan(a => a.StartDate).WithMessage("End Date must be after Start Date.");

            RuleFor(a => a.Complexity)
                .InclusiveBetween(1, 13).WithMessage("Complexity must be a valid Story Point (1, 2, 3, 5, 8, 13).");

            RuleFor(a => a.Status)
                .Equal("Not Started").When(a => a.Status == null).WithMessage("Default Status must be 'Not Started'.");

            RuleFor(a => a.ParentAssignmentId)
                .Must((assignment, parentId) => IsValidParentChildDates(assignment, parentId))
                .WithMessage("Child Assignment dates must be within parent Assignment dates.");

            RuleFor(a => a.ParentAssignmentId)
                .Must((assignment, parentId) => !HasCircularDependency(assignment, parentId))
                .WithMessage("Circular dependencies are not allowed.");
        }

        private bool IsValidParentChildDates(Assignment assignment, int? parentId)
        {
            if (parentId == null)
                return true;

            var parentAssignment = _assignmentDb.GetByIdAsync(parentId.Value).Result;
            if (parentAssignment == null)
                return false;

            return assignment.StartDate >= parentAssignment.StartDate && assignment.EndDate <= parentAssignment.EndDate;
        }

        private bool HasCircularDependency(Assignment assignment, int? parentId)
        {
            if (parentId == null)
                return false;

            var visitedAssignments = new HashSet<int>();
            var currentParentId = parentId;

            while (currentParentId != null)
            {
                if (visitedAssignments.Contains(currentParentId.Value))
                    return true;

                visitedAssignments.Add(currentParentId.Value);
                var parentAssignment = _assignmentDb.GetByIdAsync(currentParentId.Value).Result;

                if (parentAssignment == null)
                    break;

                currentParentId = parentAssignment.ParentAssignmentId;
            }

            return false;
        }
    }
}