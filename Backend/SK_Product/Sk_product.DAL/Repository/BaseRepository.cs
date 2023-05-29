using Microsoft.EntityFrameworkCore;
using Sk_product.Common.CommonModel;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.Repository
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    private readonly Sk_productContext _context;
    public BaseRepository(Sk_productContext context)
    {
      _context = context;
    }

    public void Add(T entity)
    {
      _context.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
      _context.AddRange(entities);
    }

    public async Task<List<T>> FindAll(Expression<Func<T,bool>> ex)
    {
      return await _context.Set<T>().Where(ex).ToListAsync();
    }

    public async Task<T> FindById(object id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAll()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public int GetByName(string RoleName)
    {
      return _context.Roles.Where(x=>x.Name== RoleName).FirstOrDefault().Id;
    }

   //await _carddbcontext.Users.FirstOrDefaultAsync(x => x.UserName==users.UserName)
   public  User emailget(string email)
    {
     var cc= _context.Users.Include(r=>r.UserRoles).Where(u=>u.Email==email).FirstOrDefault();
      return cc;
    }
    public void Remove(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public bool SaveChangess()
    {
      return  _context.SaveChanges()>0;
    }
    public int savChage()
    {
      return _context.SaveChanges();
    }

    public void Update(T entity)
    {
      _context.Set<T>().Update(entity);
    }
    public void Delete(int id)
    {
      T entity=_context.Set<T>().Find(id);
      if (entity != null)
      {
        _context.Remove(entity);
      }
    }
    
  }
}
