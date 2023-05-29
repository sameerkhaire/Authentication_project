using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.IRepository
{
  public interface IBaseRepository<T> where T : class
  {
    Task<List<T>> GetAll();
    Task<List<T>> FindAll(Expression<Func<T, bool>> ex);
    Task<T> FindById(object id);
    int GetByName(string Name);

    void Update(T entity);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    bool SaveChangess();
    int savChage();
    User emailget(string email);
    void Delete(int id);
  }
}
