using Application.Auth.AuthCommands.AuthCommandRequests;
using FluentValidation;

namespace Application.Auth.AuthValidators;

public class LoginAuthValidator : AbstractValidator<LoginAuthCommand>
{
    public LoginAuthValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required");
            // .Matches(@"^\+?[1-9]\d{9,14}$")
            // .WithMessage("PhoneNumber format is invalid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
