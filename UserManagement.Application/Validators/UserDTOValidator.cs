using FluentValidation;
using System;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(u => u.Name)
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(u => u.Age)
                    .NotNull().WithMessage("Age is required.")
                    .InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120.");

            //const string male = "Male";
            //const string female = "Female";
            //RuleFor(u => u.Sex)
            //        .NotNull().WithMessage("Sex is required.")
            //        .MaximumLength(10).WithMessage("Sex cannot exceed 10 characters.")
            //        .Must(s => s.Equals(male, StringComparison.CurrentCultureIgnoreCase) || s.Equals(female, StringComparison.CurrentCultureIgnoreCase)).WithMessage($"Sex must be '{male}' or '{female}'.");
        }
    }
}
