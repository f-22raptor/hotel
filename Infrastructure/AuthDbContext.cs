using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AuthDbContext(DbContextOptions<AuthDbContext>  options) : DbContext(options)
{
    
}