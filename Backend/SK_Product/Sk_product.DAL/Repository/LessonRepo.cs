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
  public class LessonRepo : BaseRepository<CourseLesson>, ILessonRepo
  {
    private readonly Sk_productContext _context;
    public LessonRepo(Sk_productContext context) : base(context)
    {
      _context = context;
    }

    public IEnumerable<CourseLesson> GetLessons(int topic_id)
    {
      IEnumerable<CourseLesson>data= (from topic in _context.CourseTopics
              join lessons in _context.CourseLessons on topic.Id equals lessons.Id
              where (topic.Id == topic_id)
              select lessons).ToList();
      return data;
    }
  }
}
