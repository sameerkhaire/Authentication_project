using Sk_product.BAL.IServices;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;

namespace Sk_product.BAL.Services
{
  public class SubscriptionService : Service<Subscription>, IsubscriptionServices
  {
    private readonly IsubscriptionRepo _subscriptionRepo;
    public SubscriptionService(IsubscriptionRepo subscriptionRepo, IBaseRepository<Subscription> repository) : base(repository)
    {
      _subscriptionRepo = subscriptionRepo;
    }

    public IEnumerable<Course> GetSubscribedCourses(int UserId)
    {
      return _subscriptionRepo.GetSubscribedCourses(UserId);
    }

    public Subscription GetUserSubscription(int UserId, int CourseId)
    {
     return _subscriptionRepo.GetUserSubscription(UserId, CourseId);
    }
  }
}
