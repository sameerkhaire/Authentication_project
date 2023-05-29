using Microsoft.EntityFrameworkCore;
using Sk_product.BAL.IServices;
using Sk_product.Common.CommonModel;
using Sk_product.Common.DTO;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BC = BCrypt.Net.BCrypt;

namespace Sk_product.BAL.Services
{
  public class UserService : IUserServices
  {
    private readonly IBaseRepository<UserSignUpModel> _repository;
    private readonly IBaseRepository<Role> _rolerepo;
    private readonly IBaseRepository<User> _userrepo;
    private readonly Sk_productContext _context;
    private readonly IBaseRepository<UserRole> _urolerepo;
    public UserService(IBaseRepository<UserSignUpModel> repository,IBaseRepository<Role> rolerepo, IBaseRepository<User> userrepo, Sk_productContext context, IBaseRepository<UserRole> urolerepo)
    {
        _repository = repository;
       _rolerepo = rolerepo;
      _userrepo = userrepo;
      _context = context;
      _urolerepo = urolerepo;
    }

    public static string HashPassword(string password)
    {
      if (string.IsNullOrEmpty(password))
      {
        return null;
      }
      else
      {
        byte[] storpass = ASCIIEncoding.ASCII.GetBytes(password);
        string encrytedpass = Convert.ToBase64String(storpass);
        return encrytedpass;
      }
    }
    public async Task<Response> Register([FromBody] UserSignUpModel userSignUp)
    {
      string password =HashPassword(userSignUp.Password);
      //var useremail = _userrepo.FindAll(x => x.Email == userSignUp.Email);
      var useremails = _userrepo.emailget(userSignUp.Email);
      if (useremails!= null)
      {
        return new Response(HttpStatusCode.BadRequest, "Email exists", userSignUp);
      }
      int role=_rolerepo.GetByName(userSignUp.Role);
      User user_ = new User()
      {
        Name = userSignUp.Name,
        Email = userSignUp.Email,
        Password = password,
        PhoneNumber = userSignUp.PhoneNumber,
        CreatedDate = DateTime.UtcNow,
        EmailConfirmed = true
      };
      //user_.Roles.Add(role);
      _userrepo.Add(user_);
      if (_userrepo.SaveChangess().Equals(true))
      {
        var userole = new UserRole()
        {
          UserId = _userrepo.FindAll(x=>x.Email==userSignUp.Email).Result.FirstOrDefault().Id,
          RoleId = role
        };
        _urolerepo.Add(userole);
        _urolerepo.SaveChangess();


        return new Response(HttpStatusCode.OK, "Registration successfully", userSignUp);
      }
      else
      {
        return new Response(HttpStatusCode.BadRequest, "Something went wrong", userSignUp);
      }
    }
  }
}
