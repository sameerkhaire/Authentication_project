

using DAL.Models;

namespace Services.ServiceInterface
{
    public interface ILessonService: IService<CourseLesson>
    {
        IEnumerable<CourseLesson> GetLessonsByTopic(int TopicId);
    }
}
