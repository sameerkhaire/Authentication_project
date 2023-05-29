using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
  public interface Iservice<TEntity> where TEntity : class
  {
    Task<List<TEntity>> GetAll();
    Task<TEntity> Find(int id);
    void Add(TEntity entity);
    void Delete(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);

  }
}
