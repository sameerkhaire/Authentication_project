using DAL.Models;
using Repositories.Interface;
using Repositories.IRepository;
using Services.ServiceInterface;

namespace Services.serviceImplemenation
{
    public class LessonService : Service<CourseLesson>, ILessonService
    {
        private readonly ILessonRepository _lessonRepo;
        public LessonService(ILessonRepository lessonRepo, IBaseRepo<CourseLesson> courseLesson) : base(courseLesson)
        {
            _lessonRepo = lessonRepo;
        }
        public IEnumerable<CourseLesson> GetLessonsByTopic(int TopicId)
        {
            return _lessonRepo.GetLessonsByTopic(TopicId);
        }
    }
}
