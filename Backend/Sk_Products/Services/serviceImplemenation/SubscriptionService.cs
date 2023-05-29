using DAL.Models;
using Repositories.Interface;
using Repositories.IRepository;
using Services.Interfaces;
using Services.ServiceInterface;
using System.Collections.Generic;

namespace Services.serviceImplemenation
{
    public class SubscriptionService : Service<Subscription>, ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepo;
        public SubscriptionService(ISubscriptionRepository subscriptionRepo, IBaseRepo<Subscription> subsRepo) : base(subsRepo)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        public Subscription GetUserSubscription(int UserId, int CourseId)
        {
            Subscription subscription = _subscriptionRepo.GetUserSubscription(UserId, CourseId);
            return subscription;
        }
        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            return _subscriptionRepo.GetSubscribedCourses(UserId);
        }
    }
}
