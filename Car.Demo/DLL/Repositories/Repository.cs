using Car.Demo.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car.Demo.DLL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity: class, IEntity
{
    private readonly CarDbContext _context;

    public Repository(CarDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<TEntity> Sql()
    {
        return _context.Set<TEntity>();
    }
    
    public async Task AddAsync(TEntity entity) =>
        await _context.Set<TEntity>().AddAsync(entity);

    public async Task UpdateAsync(TEntity entity) =>
        await Task.Run(() => _context.Set<TEntity>().Update(entity));

    public async Task DeleteAsync(TEntity entity) =>
        await Task.Run(() => _context.Set<TEntity>().Remove(entity));

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}