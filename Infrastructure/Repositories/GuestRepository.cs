using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GuestRepository(AppDbContext context) : BaseRepository<Guest, Guid>(context), IGuestRepository
{
    protected override IQueryable<Guest> CustomContext()
    {
        return context.Guests.Include(g => g.Reservations);
    }

    protected override IQueryable<Guest> CustomFilter(IQueryable<Guest> query, string? filterOn, string? filterQuery)
    {
        throw new NotImplementedException();
    }

    protected override IQueryable<Guest> CustomSort(IQueryable<Guest> query, string? orderBy, bool isAscending)
    {
        throw new NotImplementedException();
    }
}
