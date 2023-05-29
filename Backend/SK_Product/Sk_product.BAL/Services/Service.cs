using Sk_product.BAL.IServices;
using Sk_product.DAL.IRepository;

namespace Sk_product.BAL.Services
{
  public class Service<TEntity>:Iservice<TEntity> where TEntity : class
  {
    private readonly IBaseRepository<TEntity> _repository;
    public Service(IBaseRepository<TEntity> repository)
    {
      _repository = repository;
    }

    public void Add(TEntity entity)
    {
      _repository.Add(entity);
      _repository.savChage();
    }

    public void Delete(int id)
    {
      _repository.Delete(id);
      _repository.savChage();
    }

    public Task<TEntity> Find(int id)
    {
      return _repository.FindById(id);
    }

    public Task<List<TEntity>> GetAll()
    {
      return _repository.GetAll();
    }

    public void Remove(TEntity entity)
    {
      _repository.Remove(entity);
      _repository.savChage();
    }

    public void Update(TEntity entity)
    {
      _repository.Update(entity);
      _repository.savChage();
    }
  }
}
