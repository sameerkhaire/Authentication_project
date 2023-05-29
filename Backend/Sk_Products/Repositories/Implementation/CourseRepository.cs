using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation;
using Repositories.IRepository;
using Repositories.Repository;

namespace Repositories.Implementation
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private Sk_productContext dbContext
        {
            get
            {
                return _dbContext as Sk_productContext;
            }
        }
        public CourseRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Course GetCourseByUrl(string Url)
        {
            return dbContext.Courses.Where(c => c.Url == Url).FirstOrDefault();
        }
    }
}
