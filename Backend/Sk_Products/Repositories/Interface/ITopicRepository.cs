using DAL.Models;

namespace Repositories.IRepository
{
   public interface ITopicRepository
    {
        IEnumerable<CourseTopic> GetAllTopics();
        IEnumerable<CourseTopic> GetTopicWithLessons(int id);
        IEnumerable<CourseTopic> GetTopicsByCourse(int id);
    }
}
