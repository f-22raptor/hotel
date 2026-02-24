using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public interface ITokenRepository
{
    string CreateJwt(IdentityUser user, ICollection<string> roles);
}