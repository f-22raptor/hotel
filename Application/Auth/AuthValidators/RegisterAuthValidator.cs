using Application.Auth.AuthCommands.AuthCommandRequests;
using FluentValidation;

namespace Application.Auth.AuthValidators;

public class RegisterAuthValidator : AbstractValidator<RegisterAuthCommand>
{
    public RegisterAuthValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .Matches(@"^\+?[1-9]\d{9,14}$")
            .WithMessage("PhoneNumber format is invalid. Use international format, e.g. +989123456789");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(3).WithMessage("Password must be at least 8 characters")
            .MaximumLength(64).WithMessage("Password must not exceed 64 characters");
    }
}
