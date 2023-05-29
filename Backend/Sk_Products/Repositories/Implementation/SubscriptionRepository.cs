using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        private Sk_productContext dbContext
        {
            get
            {
                return _dbContext as Sk_productContext;
            }
        }
        public SubscriptionRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Subscription GetUserSubscription(int UserId, int CourseId)
        {
            return dbContext.Subscriptions.Where(c => c.UserId == UserId && c.CourseId == CourseId).FirstOrDefault();
        }

        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            IEnumerable<Course> model = (from subs in dbContext.Subscriptions
                                                    join course in dbContext.Courses
                                                    on subs.CourseId equals course.Id
                                                    where subs.UserId == UserId
                                                    select course).ToList();
            return model;
        }
    }
}
