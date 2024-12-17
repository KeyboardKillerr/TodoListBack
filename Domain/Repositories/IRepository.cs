using Domain.Models;

namespace Domain.Repositories;

public interface IRepository<T> where T : EntityBase
{
    Task CreateAsync(T entity);
    Task<T?> GetItemByIdAsync(int id);
    Task<T> UpdateAsync(T entity, int id);
    Task DeleteAsync(int id);
    Task<ICollection<T>> GetAllAsync();
}
