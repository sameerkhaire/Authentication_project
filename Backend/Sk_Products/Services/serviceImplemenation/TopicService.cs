
using DAL.Models;
using Repositories.Interface;
using Repositories.IRepository;
using Services.ServiceInterface;

namespace Services.serviceImplemenation
{
    public class TopicService : Service<CourseTopic>, ITopicService
    {
        private readonly ITopicRepository _topicRepo;
        public TopicService(ITopicRepository topicRepo, IBaseRepo<CourseTopic> courseTopic) : base(courseTopic)
        {
            _topicRepo = topicRepo;
        }
        public IEnumerable<CourseTopic> GetAllTopics()
        {
            return _topicRepo.GetAllTopics();
        }
        public IEnumerable<CourseTopic> GetTopicsByCourse(int CourseId)
        {
            return _topicRepo.GetTopicsByCourse(CourseId);
        }
    }
}
