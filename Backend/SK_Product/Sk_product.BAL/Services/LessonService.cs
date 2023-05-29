using Sk_product.BAL.IServices;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.Services
{
  public class LessonService : Service<CourseLesson>, ILessonServices
  {
    private readonly ILessonRepo _lessonRepo;
    public LessonService(ILessonRepo lessonRepo,IBaseRepository<CourseLesson> repository) : base(repository)
    {
      _lessonRepo = lessonRepo;
    }

    public IEnumerable<CourseLesson> GetLessons(int topic_id)
    {
      return _lessonRepo.GetLessons(topic_id);
    }
  }
}
