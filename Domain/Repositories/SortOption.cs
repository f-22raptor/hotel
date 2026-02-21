namespace Domain.Repositories;

public sealed record SortOption(
    string Field,
    SortDirection Direction = SortDirection.Asc);
