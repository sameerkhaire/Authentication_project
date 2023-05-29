using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class TopicRepository : BaseRepository<CourseTopic>, ITopicRepository
    {
        private Sk_productContext dbContext
        {
            get
            {
                return _dbContext as Sk_productContext;
            }
        }
        public TopicRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<CourseTopic> GetAllTopics()
        {
            var Topics = (from topic in dbContext.CourseTopics
                          join course in dbContext.Courses
                          on topic.CourseId equals course.Id
                          select new CourseTopic
                          {
                              Id = topic.Id,
                              TopicName = topic.TopicName,
                             // CourseName = course.Name,
                              IsActive = topic.IsActive
                          }).ToList();
            return Topics;
        }

        public IEnumerable<CourseTopic> GetTopicWithLessons(int id)
        {
           var Topics = dbContext.CourseTopics.Where(c => c.CourseId == id).Include(c=>c.CourseLessons).ToList();
            return Topics;
        }

        public IEnumerable<CourseTopic> GetTopicsByCourse(int id)
        {
            var Topics = (from topic in dbContext.CourseTopics
                          where topic.CourseId == id
                          select topic).ToList();
            return Topics;
        }
    }
}
