using Car.Demo.DLL.Entities;

namespace Car.Demo.DLL.Repositories;

public interface IRepository<TEntity> where TEntity: class, IEntity
{
    IQueryable<TEntity> Sql();
    
    Task AddAsync(TEntity entity);
    
    Task UpdateAsync(TEntity entity);
    
    Task DeleteAsync(TEntity entity);
    
    Task<int> SaveChangesAsync();
}