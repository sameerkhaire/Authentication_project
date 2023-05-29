using DAL.Models;

namespace Services.ServiceInterface
{
    public interface ISubscriptionService : IService<Subscription>
    {
        Subscription GetUserSubscription(int UserId, int CourseId);
        IEnumerable<Course> GetSubscribedCourses(int UserId);
    }
}
