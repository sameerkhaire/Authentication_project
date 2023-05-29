using Microsoft.Extensions.Configuration;
using Sk_product.BAL.IServices;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using Sk_product.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.Services
{
  public class courseServices : Service<Course>, IcourseServices
  {
    private readonly CourseRepo _repo;
    private readonly IConfiguration _config;
    private readonly ITopicRepo _topicrepo;
    private readonly Iservice<Mentor> _mentor;
    public courseServices(Iservice<Mentor> mentor,ITopicRepo topicRepo, CourseRepo repo,IBaseRepository<Course> repository, IConfiguration config) : base(repository)
    {
      _repo = repo;
      _config = config;
      _topicrepo = topicRepo;
      _mentor = mentor;
    }

    public IEnumerable<Course> GetAllCourses()
    {
      var data=_repo.GetAll().Result.Select(x => new Course
               {
                 Id = x.Id,
                 Name = x.Name,
                 DemoUrl = x.DemoUrl,
                 ImageUrl = _config["Imageurl"] +x.ImageUrl,
                 MentorId = x.MentorId,
                 Sequence = x.Sequence,
                 DifficultyType = x.DifficultyType,
                 Summary = x.Summary,
                 UnitPrice = x.UnitPrice,
                 Description = x.Description,
                 Url = x.Url

               });
      return data;
    }

    public Course GetCourseWithLesson(string url)
    {
      Course course = _repo.GetcourseBylesson(url);
      course.Mentor = _mentor.Find(course.MentorId).Result;
      course.Mentor.ImageUrl = _config["Imageurl"] + course.Mentor.ImageUrl;
      course.CourseTopics = _topicrepo.GetTopicWithLessons(course.Id).ToList();
      return course;
    }
  }
}
