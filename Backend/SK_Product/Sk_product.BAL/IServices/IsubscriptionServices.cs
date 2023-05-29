using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
  public interface IsubscriptionServices : Iservice<Subscription>
  {
    Subscription GetUserSubscription(int UserId, int CourseId);
    IEnumerable<Course> GetSubscribedCourses(int UserId);
  }
}
