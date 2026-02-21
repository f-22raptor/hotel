using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HotelRepository(AppDbContext context) : BaseRepository<Hotel, Guid>(context), IHotelRepository
{
    protected override IQueryable<Hotel> CustomContext()
    {
        return context.Hotels.Include(h => h.Rooms);
    }

    protected override IQueryable<Hotel> ApplySorting(IQueryable<Hotel> query, IReadOnlyList<SortOption>? sorts)
    {
        if (sorts == null || sorts.Count == 0)
        {
            return query.OrderBy(h => h.Name);
        }

        IOrderedQueryable<Hotel>? orderedQuery = null;
        foreach (var sort in sorts)
        {
            orderedQuery = sort.Field.ToLowerInvariant() switch
            {
                "name" => ApplyOrder(orderedQuery, query, h => h.Name, sort.Direction),
                "rating" => ApplyOrder(orderedQuery, query, h => h.Rating, sort.Direction),
                _ => orderedQuery
            };
        }

        return orderedQuery ?? query.OrderBy(h => h.Name);
    }

    private static IOrderedQueryable<Hotel> ApplyOrder<TProperty>(
        IOrderedQueryable<Hotel>? orderedQuery,
        IQueryable<Hotel> query,
        System.Linq.Expressions.Expression<Func<Hotel, TProperty>> keySelector,
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
