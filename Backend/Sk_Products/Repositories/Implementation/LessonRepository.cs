using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation;
using Repositories.IRepository;

namespace Repositories.Implementation
{
    public class LessonRepository: BaseRepository<CourseLesson>, ILessonRepository
    {
        private Sk_productContext dbContext
        {
            get
            {
                return _dbContext as Sk_productContext;
            }
        }
        public LessonRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<CourseLesson> GetLessonsByTopic(int id)
        {
            var Lessons = (from topic in dbContext.CourseTopics
                           join lessons in dbContext.CourseLessons
                           on topic.Id equals lessons.CourseTopicId
                           where topic.Id == id
                           select lessons).ToList();
            return Lessons;
        }
    }
}
