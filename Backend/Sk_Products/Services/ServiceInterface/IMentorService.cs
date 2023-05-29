

using DAL.Models;

namespace Services.ServiceInterface
{
    public interface IMentorService : IService<Mentor>
    {
        IEnumerable<Mentor> GetAllMentors();
    }
}
