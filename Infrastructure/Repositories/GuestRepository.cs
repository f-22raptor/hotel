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

    protected override IQueryable<Guest> ApplySorting(IQueryable<Guest> query, IReadOnlyList<SortOption>? sorts)
    {
        if (sorts == null || sorts.Count == 0)
        {
            return query.OrderBy(g => g.FullName);
        }

        IOrderedQueryable<Guest>? orderedQuery = null;
        foreach (var sort in sorts)
        {
            orderedQuery = sort.Field.ToLowerInvariant() switch
            {
                "name" or "fullname" => ApplyOrder(orderedQuery, query, g => g.FullName, sort.Direction),
                "email" => ApplyOrder(orderedQuery, query, g => g.Email, sort.Direction),
                _ => orderedQuery
            };
        }

        return orderedQuery ?? query.OrderBy(g => g.FullName);
    }

    private static IOrderedQueryable<Guest> ApplyOrder<TProperty>(
        IOrderedQueryable<Guest>? orderedQuery,
        IQueryable<Guest> query,
        System.Linq.Expressions.Expression<Func<Guest, TProperty>> keySelector,
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
