using EFCore_Sample.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Sample.Repository;

public class Repository<TEntity> : IRepository<TEntity>, IDisposable
    where TEntity : class
{
    private readonly BlogDbContext _dbContext;
    private DbSet<TEntity> _entities;

    public Repository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }


    public Task<List<TEntity>> GetAll()
    {
        return _entities.ToListAsync();
    }

    public async Task<TEntity?> Get(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task Insert(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }

    public void Delete(int id)
    {
        TEntity? entity = _entities.Find(id);
        if (entity != null)
            _entities.Remove(entity);
    }

    public async Task Save()
    {
       await _dbContext.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}