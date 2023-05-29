using Sk_product.BAL.IServices;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.Services
{
  public class MentorService:Service<Mentor>, ImentorServices
  {
    private readonly IBaseRepository<Mentor> _baseRepository;
    public MentorService(IBaseRepository<Mentor> repository) : base(repository)
    {
      _baseRepository = repository;
    }

    public IEnumerable<Mentor> GetAllMentors()
    {

      var data = _baseRepository.GetAll().Result.Select(x => new Mentor()
      {
        Id= x.Id,
        Name= x.Name,
        Email= x.Email,
        Title= x.Title,
        Biography= x.Biography,
        Skills= x.Skills,
        IsActive= x.IsActive,
      }).ToList();
      return data;
    }
  }
}
