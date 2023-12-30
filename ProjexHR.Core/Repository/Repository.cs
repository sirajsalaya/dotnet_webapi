using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ProjexHR.Core;

public class Repository<TEntity> : IDisposable where TEntity : class
{
    internal DbContext _context;
    internal DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
        this._dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> FindAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity?> FindWithTrackingAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetIEnumerableAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetIEnumerableWithTrackingAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetIEnumerableAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetIEnumerableWithTrackingAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public IQueryable<TEntity> GetIQueryable()
    {
        return _dbSet.AsNoTracking();
    }

    public IQueryable<TEntity> GetIQueryableWithTracking()
    {
        return _dbSet;
    }

    public IQueryable<TEntity> GetIQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate);
    }

    public IQueryable<TEntity> GetIQueryableWithTracking(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().CountAsync(predicate);
    }

    public virtual bool IsExists(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Count(predicate) > 0;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        return entities;
    }

    public TEntity? Update(TEntity entity)
    {
        if (entity is null)
        {
            return null;
        }

        _context.Update(entity);
        return entity;
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task<bool> Delete(object id)
    {
        if (id is null)
        {
            return false;
        }

        TEntity? entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            return false;
        }
        _dbSet.Remove(entity);
        return true;
    }

    public bool Delete(TEntity entity)
    {
        if (entity is null)
        {
            return false;
        }

        _dbSet.Remove(entity);
        return true;
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        if (_context.Entry(entities).State == EntityState.Detached)
        {
            _dbSet.AttachRange(entities);
        }
        _dbSet.RemoveRange(entities);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
