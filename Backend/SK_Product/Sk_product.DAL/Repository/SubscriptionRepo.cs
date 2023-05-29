using Microsoft.EntityFrameworkCore;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.Repository
{
  public class SubscriptionRepo : BaseRepository<Subscription>, IsubscriptionRepo
  {
    private Sk_productContext _context;
    public SubscriptionRepo(Sk_productContext context) : base(context)
    {
      _context = context;
    }
    public IEnumerable<Course> GetSubscribedCourses(int UserId)
    {
      IEnumerable<Course> data = (from subs in _context.Subscriptions join course in _context.Courses on subs.CourseId equals course.Id where subs.UserId == UserId select course).ToList();
      return data;
    }

    public Subscription GetUserSubscription(int UserId, int CourseId)
    {
      return _context.Subscriptions.Where(x => x.UserId == UserId && x.CourseId==CourseId).FirstOrDefault();
    }
  }
}
