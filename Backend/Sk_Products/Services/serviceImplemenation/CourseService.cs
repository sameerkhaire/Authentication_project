using DAL.Models;
using Microsoft.Extensions.Configuration;
using Repositories.Interface;
using Repositories.IRepository;
using Services.ServiceInterface;


namespace Services.serviceImplemenation
{
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IBaseRepo<Mentor> _mentorRepo;
        private readonly ITopicRepository _topicRepository;
        private readonly IConfiguration _config;
        public CourseService(ICourseRepository courseRepo, ITopicRepository topicRepo, IBaseRepo<Mentor> mentorRepo, IConfiguration config) : base(courseRepo)
        {
            _courseRepo = courseRepo;
            _topicRepository = topicRepo;
            _mentorRepo = mentorRepo;
            _config = config;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            var data = _courseRepo.GetAll().Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name,
                DemoUrl = c.DemoUrl,
                ImageUrl = _config["ImageBaseUrl"] + c.ImageUrl,
                MentorId = c.MentorId,
                Sequence = c.Sequence,
                DifficultyType = c.DifficultyType,
                Summary = c.Summary,
                UnitPrice = c.UnitPrice,
                Description = c.Description,
                Url = c.Url
            });
            return data;
        }
        public Course GetCourseWithLessons(string Url)
        {
            Course course = _courseRepo.GetCourseByUrl(Url);
            course.Mentor = _mentorRepo.Find(course.MentorId);
            course.Mentor.ImageUrl = _config["ImageBaseUrl"] + course.Mentor.ImageUrl;
            course.CourseTopics = _topicRepository.GetTopicWithLessons(course.Id).ToList();

            return course;
        }

    }
}
