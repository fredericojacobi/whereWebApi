using System.Linq.Expressions;
using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
{
    private DatabaseContext _context { get; }

    public RepositoryBase(DatabaseContext context) => _context = context;

    public async Task<T?> ReadById(Guid id) => await _context.Set<T>().FindAsync(id);

    public async Task<ICollection<T>> ReadAllAsync(params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().AsQueryable();
        if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
        includeExpressions.ToList().ForEach(x => query = query.Include(x));
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<ICollection<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().Where(expression);
        if (!includeExpressions.Any()) return await query.AsNoTracking().ToListAsync();
        includeExpressions.ToList().ForEach(x => query = query.Include(x));
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return await SaveAndReturnEntityAsync(entity);
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        _context.Set<T>().Update(entity);
        return await UpdateAndReturnEntityAsync(entity);
    }

    public async Task<ICollection<T>> UpdateRangeAsync(ICollection<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        return await UpdateAndReturnEntitiesAsync(entities);
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity is null) return false;
        _context.Remove(entity);
        return await SaveAsync();
    }

    public async Task<bool> DeleteRangeAsync(ICollection<T> entities)
    {
        _context.RemoveRange(entities);
        return await SaveAsync();
    }

    public async Task<bool> DeleteRangeAsync(ICollection<Guid> ids)
    {
        var entities = await _context.Set<T>().FindAsync(ids);
        if (entities is null) return false;
        _context.RemoveRange(entities);
        return await SaveAsync();
    }

    private async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

    private async Task<T> SaveAndReturnEntityAsync(T entity)
    {
        entity.CreatedAt = DateTime.Now;   
        await _context.SaveChangesAsync();
        await _context.Entry(entity).ReloadAsync();
        return entity;
    }

    private async Task<ICollection<T>> SaveAndReturnEntitiesAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
            entity.CreatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        await _context.Entry(entities).ReloadAsync();
        return entities;
    }

    private async Task<T> UpdateAndReturnEntityAsync(T entity)
    {
        entity.ModifiedAt = DateTime.Now;   
        await _context.SaveChangesAsync();
        await _context.Entry(entity).ReloadAsync();
        return entity;
    }
    
    private async Task<ICollection<T>> UpdateAndReturnEntitiesAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
            entity.ModifiedAt = DateTime.Now;
        
        await _context.SaveChangesAsync();
        await _context.Entry(entities).ReloadAsync();
        return entities;
    }
    
    
}