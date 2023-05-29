using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Sk_product.BAL.IServices;
using Sk_product.BAL.Services;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using Sk_product.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.Configurations
{
  public static class ConfigurationDependencies
  {
      public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
      {
        services.AddDbContext<Sk_productContext>((options) =>
        {
          options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        });

        services.AddScoped<DbContext, Sk_productContext>();
      services.TryAdd(ServiceDescriptor.Singleton<IcartRepo, CartRepository>());
      services.TryAdd(ServiceDescriptor.Singleton<IcourseRepo,CourseRepo>());
      services.TryAdd(ServiceDescriptor.Singleton<ILessonRepo, LessonRepo>());
      //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
      //services.AddScoped<IcartRepo, CartRepository>();
      //  services.AddScoped<IcourseRepo, CourseRepo>();
      //  services.AddScoped<ILessonRepo, LessonRepo>();

      services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
      services.AddScoped<IBaseRepository<Course>, BaseRepository<Course>>();
      services.AddScoped<IBaseRepository<Mentor>, BaseRepository<Mentor>>();
      services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
      services.AddScoped<IBaseRepository<CourseTopic>, BaseRepository<CourseTopic>>();
      services.AddScoped<IBaseRepository<CourseLesson>, BaseRepository<CourseLesson>>();
      services.AddScoped<IBaseRepository<Subscription>, BaseRepository<Subscription>>();
      services.AddScoped<IBaseRepository<CartItem>, BaseRepository<CartItem>>();
      services.AddScoped<IBaseRepository<OrderItem>, BaseRepository<OrderItem>>();
      services.AddScoped<IBaseRepository<PaymentDetail>, BaseRepository<PaymentDetail>>();


      services.TryAdd(ServiceDescriptor.Singleton<ITopicRepo, TopicRepo>());
      services.TryAdd(ServiceDescriptor.Singleton<IorderRepo, OrderRepo>());
      services.TryAdd(ServiceDescriptor.Singleton<IsubscriptionRepo, SubscriptionRepo>());
      //services.AddScoped<ITopicRepo, TopicRepo>();
      //  services.AddScoped<IorderRepo, OrderRepo>();
      //  services.AddScoped<IsubscriptionRepo, SubscriptionRepo>();



      //Services
      //services.AddScoped(typeof(Iservice<>), typeof(Service<>));
      services.TryAdd(ServiceDescriptor.Singleton<IUserServices, UserService>());
      services.TryAdd(ServiceDescriptor.Singleton<ITokenServices, TokenServices>());
      //services.AddScoped<IUserServices, UserService>();
      //  services.AddScoped<ITokenServices,TokenServices>();
        services.AddScoped<Iservice<Course>, Service<Course>>();
        services.AddScoped<Iservice<CourseTopic>, Service<CourseTopic>>();
        services.AddScoped<Iservice<CourseLesson>, Service<CourseLesson>>();
        services.AddScoped<Iservice<Category>, Service<Category>>();
        services.AddScoped<Iservice<Subscription>, Service<Subscription>>();
        services.AddScoped<Iservice<Mentor>, Service<Mentor>>();

        services.TryAdd(ServiceDescriptor.Singleton<IcartServices, CartService>());
        services.TryAdd(ServiceDescriptor.Singleton<IorderServices, OrderService>());
        services.TryAdd(ServiceDescriptor.Singleton<ITopicServices, TopicService>());
        services.TryAdd(ServiceDescriptor.Singleton<ILessonServices, LessonService>());
        services.TryAdd(ServiceDescriptor.Singleton<IcourseServices, courseServices>());
        services.TryAdd(ServiceDescriptor.Singleton<IsubscriptionServices, SubscriptionService>());
        services.TryAdd(ServiceDescriptor.Singleton<ImentorServices, MentorService>());
      //services.AddScoped<IcartServices, CartService>();
      //services.AddScoped<IorderServices, OrderService>();
      //services.AddScoped<ITopicServices, TopicService>();
      //services.AddScoped<ILessonServices, LessonService>();
      //services.AddScoped<IcourseServices, courseServices>();
      //services.AddScoped<IsubscriptionServices, SubscriptionService>();
      //services.AddScoped<ImentorServices, MentorService>();

    }
  }
}
