using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.IRepository
{
  public interface ITopicRepo : IBaseRepository<CourseTopic>
  {
    IEnumerable<CourseTopic> GetAllTopics();
    IEnumerable<CourseTopic> GetTopicWithLessons(int id);
    IEnumerable<CourseTopic> GetTopicsByCourse(int id);
  }
}
