using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomRepository(AppDbContext context) : BaseRepository<Room, Guid>(context), IRoomRepository
{
    protected override IQueryable<Room> CustomContext()
    {
        return context.Rooms.Include(r => r.Hotel).Include(r => r.Reservations);
    }

    protected override IQueryable<Room> ApplySorting(IQueryable<Room> query, IReadOnlyList<SortOption>? sorts)
    {
        if (sorts == null || sorts.Count == 0)
        {
            return query.OrderBy(r => r.Number);
        }

        IOrderedQueryable<Room>? orderedQuery = null;
        foreach (var sort in sorts)
        {
            orderedQuery = sort.Field.ToLowerInvariant() switch
            {
                "name" or "hotelname" => ApplyOrder(orderedQuery, query, r => r.Hotel.Name, sort.Direction),
                "price" => ApplyOrder(orderedQuery, query, r => r.PricePerNight, sort.Direction),
                "number" => ApplyOrder(orderedQuery, query, r => r.Number, sort.Direction),
                _ => orderedQuery
            };
        }

        return orderedQuery ?? query.OrderBy(r => r.Number);
    }

    private static IOrderedQueryable<Room> ApplyOrder<TProperty>(
        IOrderedQueryable<Room>? orderedQuery,
        IQueryable<Room> query,
        System.Linq.Expressions.Expression<Func<Room, TProperty>> keySelector,
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
