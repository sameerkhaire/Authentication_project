using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
  public interface ITopicServices : Iservice<CourseTopic>
  {
    IEnumerable<CourseTopic> GetAllTopics();
    IEnumerable<CourseTopic> GetTopicsByCourse(int id);
  }
}
