using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.DAL.Repository
{
  public class CourseRepo : BaseRepository<Course>, IcourseRepo
  {
    private readonly Sk_productContext _context;
    public CourseRepo(Sk_productContext context) : base(context)
    {
      _context = context;
    }

 

    public Course GetcourseBylesson(string url)
    {
      return _context.Courses.Where(x => x.Url == url).FirstOrDefault();
    }
  }
}
