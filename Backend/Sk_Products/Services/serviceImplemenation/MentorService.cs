using DAL.Models;
using Microsoft.Extensions.Configuration;
using Repositories.Interface;
using Services.ServiceInterface;

namespace Services.serviceImplemenation
{
    public class MentorService : Service<Mentor>, IMentorService
    {
        private readonly IBaseRepo<Mentor> _mentorRepo;
        private readonly IConfiguration _config;
        public MentorService(IBaseRepo<Mentor> mentorRepo, IConfiguration config) : base(mentorRepo)
        {
            _mentorRepo = mentorRepo;
            _config = config;
        }
        public IEnumerable<Mentor> GetAllMentors()
        {
            var data = _mentorRepo.GetAll().Select(c => new Mentor
            {
                Id = c.Id,
                Name = c.Name,
                Email= c.Email,
                Title= c.Title,
                Skills= c.Skills,
                Biography= c.Biography,
                ImageUrl = _config["ImageBaseUrl"] + c.ImageUrl,
            });
            return data;
        }
    }
}
