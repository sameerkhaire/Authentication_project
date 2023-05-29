using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implementation
{
  public class BaseRepository<TEntity> : IBaseRepo<TEntity> where TEntity : class
  {
    public readonly DbContext _dbContext;
    public BaseRepository(DbContext dbContext)
    {
      _dbContext=dbContext;
    }
    public void Add(TEntity entity)
    {
      _dbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
      _dbContext.Set<TEntity>().AddRange(entities);
    }

    public void Delete(object Id)
    {
      TEntity tentity = _dbContext.Set<TEntity>().Find(Id);
      if(tentity != null)
      {
        _dbContext.Set<TEntity>().Remove(tentity);
      }
    }

    public TEntity Find(object Id)
    {
      return _dbContext.Set<TEntity>().Find(Id);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _dbContext.Set<TEntity>().ToList();
    }

    public void Remove(TEntity entity)
    {
      _dbContext.Set<TEntity>().Remove(entity);
    }

    public int SaveChanges()
    {
      return _dbContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
      _dbContext.Set<TEntity>().Update(entity);
    }
  }
}
