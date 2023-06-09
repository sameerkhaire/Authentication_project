using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IBaseRepo<TEntity> where TEntity : class
    {
    IEnumerable<TEntity> GetAll();
    TEntity Find(object Id);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void Delete(object Id);
    int SaveChanges();
  }
}
