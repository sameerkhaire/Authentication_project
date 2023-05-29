using Sk_product.BAL.Services;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
  public interface IcourseServices:Iservice<Course>
  {

    IEnumerable<Course> GetAllCourses();
    Course GetCourseWithLesson(string url);
  }
}
