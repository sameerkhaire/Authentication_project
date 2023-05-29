using Sk_product.DAL.Models;
using Sk_product.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.IRepository
{
  public interface ILessonRepo:IBaseRepository<CourseLesson>
  {
    IEnumerable<CourseLesson> GetLessons(int topic_id);
  }
}
