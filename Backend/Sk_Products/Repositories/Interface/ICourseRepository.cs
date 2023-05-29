using DAL.Models;
using Repositories.Interface;

namespace Repositories.IRepository
{
    public interface ICourseRepository : IBaseRepo<Course>
    {
        Course GetCourseByUrl(string Url);
    }
}
