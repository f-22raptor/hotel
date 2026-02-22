using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity, TKey>(AppDbContext context) : IBaseRepository<TEntity, TKey>
    where TEntity : class, IBaseModel<TKey>
    where TKey : IEquatable<TKey>
{
    public virtual async Task<ICollection<TEntity>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
        string? orderBy = null, bool isAscending = true, 
        int pageNumber = 1, int pageSize = int.MaxValue)
    {
        var query = CustomContext();

        // filtering
        query = CustomFilter(query, filterOn, filterQuery);
        // sorting
        query = CustomSort(query, orderBy, isAscending);
        // pagination
        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await CustomContext().FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public virtual async Task<TEntity?> InsertAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> DeleteAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return null;

        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    protected abstract IQueryable<TEntity> CustomContext();
    protected abstract IQueryable<TEntity> CustomFilter(IQueryable<TEntity> query, string? filterOn, string? filterQuery);
    protected abstract IQueryable<TEntity> CustomSort(IQueryable<TEntity> query, string? orderBy, bool isAscending);
}