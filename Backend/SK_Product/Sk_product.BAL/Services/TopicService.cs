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
  public class TopicService : Service<CourseTopic>, ITopicServices
  {
    private readonly ITopicRepo _repo;
    public TopicService(ITopicRepo repo,IBaseRepository<CourseTopic> repository) : base(repository)
    {
      _repo = repo;
    }

    public IEnumerable<CourseTopic> GetAllTopics()
    {
      return _repo.GetAllTopics();
    }

    public IEnumerable<CourseTopic> GetTopicsByCourse(int id)
    {
      return _repo.GetTopicsByCourse(id);
    }
  }
}
