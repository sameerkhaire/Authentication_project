using DAL.Models;

namespace Repositories.IRepository
{
    public interface ILessonRepository
    {
        IEnumerable<CourseLesson> GetLessonsByTopic(int id);
    }
}
