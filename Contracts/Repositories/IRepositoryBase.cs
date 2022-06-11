using System.Linq.Expressions;

namespace Contracts.Repositories;

public interface IRepositoryBase<T>
{
    Task<T?> ReadById(Guid id);

    Task<ICollection<T>> ReadAllAsync(params Expression<Func<T, object>>[] includeExpressions);

    Task<ICollection<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeExpressions);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(Guid id, T entity);

    Task<ICollection<T>> UpdateRangeAsync(ICollection<T> entities);

    Task<bool> DeleteAsync(T entity);

    Task<bool> DeleteAsync(Guid id);

    Task<bool> DeleteRangeAsync(ICollection<T> entities);

    Task<bool> DeleteRangeAsync(ICollection<Guid> ids);
}