using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.IRepository
{
  public interface IsubscriptionRepo:IBaseRepository<Subscription>
  {
    Subscription GetUserSubscription(int UserId, int CourseId);
    IEnumerable<Course> GetSubscribedCourses(int UserId);
  }
}
