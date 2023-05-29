using DAL.Models;

namespace Services.ServiceInterface
{
    public interface ICourseService : IService<Course>
    {
        Course GetCourseWithLessons(string Url);
        IEnumerable<Course> GetAllCourses();
    }
}
