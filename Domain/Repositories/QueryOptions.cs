namespace Domain.Repositories;

public sealed record QueryOptions(
    int PageNumber = 1,
    int PageSize = 10,
    IReadOnlyList<SortOption>? Sorts = null);
