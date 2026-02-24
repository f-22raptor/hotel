using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Repositories;

public class ReservationRepository(AppDbContext context)
    : BaseRepository<Reservation, Guid>(context), IReservationRepository
{
    protected override IQueryable<Reservation> CustomContext()
    {
        return context.Reservations
            .Include(r => r.Room);
    }

    protected override IQueryable<Reservation> CustomFilter(IQueryable<Reservation> query, string? filterOn,
        string? filterQuery)
    {
        return query;
    }

    protected override IQueryable<Reservation> CustomSort(IQueryable<Reservation> query, string? orderBy,
        bool isAscending)
    {
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            // sort by reservation total price
            if (orderBy.Equals("TotalPrice", StringComparison.OrdinalIgnoreCase))
                query = isAscending
                    ? query.OrderBy(r => r.TotalPrice)
                    : query.OrderByDescending(r => r.TotalPrice);
        }
        
        return query;
    }
}