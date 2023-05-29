

using DAL.Models;

namespace Services.ServiceInterface
{
    public interface ITopicService: IService<CourseTopic>
    {
        IEnumerable<CourseTopic> GetAllTopics();
        IEnumerable<CourseTopic> GetTopicsByCourse(int CourseId);
    }
}
