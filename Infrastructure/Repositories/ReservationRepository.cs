using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReservationRepository(AppDbContext context) : BaseRepository<Reservation, Guid>(context), IReservationRepository
{
    protected override IQueryable<Reservation> CustomContext()
    {
        return context.Reservations
            .Include(r => r.Guest)
            .Include(r => r.Room)
            .ThenInclude(room => room.Hotel);
    }

    protected override IQueryable<Reservation> ApplySorting(
        IQueryable<Reservation> query,
        IReadOnlyList<SortOption>? sorts)
    {
        if (sorts == null || sorts.Count == 0)
        {
            return query.OrderBy(r => r.CheckInDate);
        }

        IOrderedQueryable<Reservation>? orderedQuery = null;
        foreach (var sort in sorts)
        {
            orderedQuery = sort.Field.ToLowerInvariant() switch
            {
                "checkin" => ApplyOrder(orderedQuery, query, r => r.CheckInDate, sort.Direction),
                "checkout" => ApplyOrder(orderedQuery, query, r => r.CheckOutDate, sort.Direction),
                "price" => ApplyOrder(orderedQuery, query, r => r.TotalPrice, sort.Direction),
                _ => orderedQuery
            };
        }

        return orderedQuery ?? query.OrderBy(r => r.CheckInDate);
    }

    private static IOrderedQueryable<Reservation> ApplyOrder<TProperty>(
        IOrderedQueryable<Reservation>? orderedQuery,
        IQueryable<Reservation> query,
        System.Linq.Expressions.Expression<Func<Reservation, TProperty>> keySelector,
        SortDirection direction)
    {
        if (orderedQuery == null)
        {
            return direction == SortDirection.Asc
                ? query.OrderBy(keySelector)
                : query.OrderByDescending(keySelector);
        }

        return direction == SortDirection.Asc
            ? orderedQuery.ThenBy(keySelector)
            : orderedQuery.ThenByDescending(keySelector);
    }
}
