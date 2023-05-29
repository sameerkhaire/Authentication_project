using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.API.Helper;
using Sk_product.BAL.IServices;
using Sk_product.BAL.Services;
using Sk_product.Common.CommonModel;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System.Net;
using BC = BCrypt.Net.BCrypt;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserServices _userServices;
    private readonly ITokenServices _tokenservice;
    private readonly IBaseRepository<User> _userrepo;
    public UserController(IUserServices userServices, ITokenServices tokenservices, IBaseRepository<User> userrepo)
    {
      _userServices = userServices;
      _tokenservice = tokenservices;
      _userrepo = userrepo;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]UserSignUpModel userSignUp)
    {
      if (userSignUp == null)
      {
        return BadRequest(HttpStatusCode.BadRequest);
      }
      else
      {
        var users = _userServices.Register(userSignUp);
        return Ok(users);
      }
    }
    [HttpPost("authenticate")]
    public async Task<IActionResult> Verifyregister([FromBody] LoginModel loginModel)
    {
      var useremails = _userrepo.emailget(loginModel.Username);
      if (useremails == null)
      {
        return null;
      }
      if (PasswordHasher.DecryptedPassword(useremails.Password)==loginModel.Password)
      {
        var Token = _tokenservice.GetToken(useremails);
        if (Token == null)
        {
          return NotFound();
        }
        return Ok(new { Token, Message = "Hello, welcome !!" + useremails.Name });
       
      }
      return BadRequest(HttpStatusCode.BadRequest);


    }
  }
}
