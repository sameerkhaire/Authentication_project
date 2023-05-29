using DAL.Models;
using Repositories.Interface;

namespace Repositories.IRepository
{
    public interface ISubscriptionRepository : IBaseRepo<Subscription>
    {
        Subscription GetUserSubscription(int UserId, int CourseId);
        IEnumerable<Course> GetSubscribedCourses(int UserId);
    }
}
