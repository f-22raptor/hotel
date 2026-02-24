using Application.Auth.AuthCommands.AuthCommandRequests;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.AuthCommands.AuthCommandHandlers;

public class RregisterAuthHandler(UserManager<IdentityUser> userManager) : IRequestHandler<RegisterAuthCommand, bool>
{
    public async Task<bool> Handle(RegisterAuthCommand request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser
        {
            PhoneNumber = request.PhoneNumber
        };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded || request.Roles.Length == 0)
            return false;
        result = await userManager.AddToRolesAsync(user, request.Roles);
        if (result.Succeeded)
            return true;
        return false;
    }
}