using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sk_product.API.Helper;
using Sk_product.BAL.Configurations;
using Sk_product.BAL.IServices;
using Sk_product.BAL.Services;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using Sk_product.DAL.Repository;
using System.Text;
using System.Text.Json.Serialization;

namespace Sk_product.API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      //builder.Services.AddDbContext<Sk_productContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
      //builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
      //builder.Services.AddTransient<ILessonRepo,LessonRepo>();
      //builder.Services.AddTransient<IcartRepo,CartRepository>();
      //builder.Services.AddTransient<IcourseRepo,CourseRepo>();
      //builder.Services.AddTransient<IorderRepo,OrderRepo>();
      //builder.Services.AddTransient<IsubscriptionRepo,SubscriptionRepo>();
      //builder.Services.AddTransient<ITopicRepo, TopicRepo>();
      //builder.Services.AddTransient(typeof(Iservice<>), typeof(Service<>));
      //builder.Services.AddTransient<IcartServices,CartService>();
      //builder.Services.AddTransient<IcourseServices,courseServices>();
      //builder.Services.AddTransient<IorderServices,OrderService>();
      //builder.Services.AddTransient<IsubscriptionServices,SubscriptionService>();
      //builder.Services.AddTransient<ITopicServices,TopicService>();
      //builder.Services.AddTransient<IUserServices, UserService>();
      //builder.Services.AddTransient<ITokenServices, TokenServices>();
      //builder.Services.AddTransient<ImentorServices, MentorService>();
      //builder.Services.AddTransient<ILessonServices, LessonService>();
      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           ConfigurationDependencies.RegisterServices(builder.Services, builder.Configuration);
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
 
      builder.Services.AddControllers()
.AddJsonOptions(
x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
      builder.Services.AddMemoryCache();
      builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
      {
        o.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidIssuer = builder.Configuration["Jwt:Issuer"],
          ValidAudience = builder.Configuration["Jwt:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
        };
      });
      builder.Services.AddCors(p =>
      {
        p.AddPolicy("sam", o => {
          o.AllowAnyHeader();
          o.WithOrigins("http://localhost:4200");
          o.AllowAnyMethod();
        });
      });

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();
      app.UseCors("sam");
      app.UseAuthentication();
      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
