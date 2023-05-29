using Microsoft.EntityFrameworkCore;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.Repository
{
  public class TopicRepo : BaseRepository<CourseTopic>, ITopicRepo
  {
    private readonly Sk_productContext _context;
    public TopicRepo(Sk_productContext context) : base(context)
    {
      _context = context;
    }

    public IEnumerable<CourseTopic> GetAllTopics()
    {
      var data = (from topic in _context.CourseTopics
                  join courses in _context.Courses on topic.CourseId equals courses.Id
                  select new CourseTopic
                  {
                    TopicName = topic.TopicName,
                    IsActive = topic.IsActive,
                    Sequence = topic.Sequence,
                  }).ToList();
      return data;
    }

    public IEnumerable<CourseTopic> GetTopicsByCourse(int id)
    {
      return _context.CourseTopics.Where(x => x.CourseId == id).Include(x => x.CourseLessons).ToList();
    }

    public IEnumerable<CourseTopic> GetTopicWithLessons(int id)
    {
      return _context.CourseTopics.Where(x => x.CourseId == id).Select(x => new CourseTopic
      {
        TopicName = x.TopicName,
        IsActive = x.IsActive,
        Sequence = x.Sequence,
      }).ToList();
    }
  }
}
