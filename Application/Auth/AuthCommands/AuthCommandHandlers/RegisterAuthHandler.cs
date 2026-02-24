using Application.Auth.AuthCommands.AuthCommandRequests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Auth.AuthCommands.AuthCommandHandlers;

public class RregisterAuthHandler(UserManager<IdentityUser> userManager) : IRequestHandler<RegisterAuthCommand, bool>
{
    public async Task<bool> Handle(RegisterAuthCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber,
            cancellationToken);
        if (existingUser != null)
            return false;

        var user = new IdentityUser
        {
            PhoneNumber = request.PhoneNumber,
            UserName = request.PhoneNumber
        };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return false;

        result = await userManager.AddToRoleAsync(user, "Guest");
        return result.Succeeded;
    }
}
