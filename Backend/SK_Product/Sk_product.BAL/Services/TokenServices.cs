using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sk_product.BAL.IServices;
using Sk_product.Common.CommonModel;
using Sk_product.DAL.IRepository;
using Sk_product.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Sk_product.BAL.Services
{
  public class TokenServices:ITokenServices
  {
    private readonly IBaseRepository<Role> _rolerepo;
    private readonly IBaseRepository<User> _userrepo;
    private readonly Sk_productContext _context;
    private readonly IBaseRepository<UserRole> _urolerepo;
    private readonly IConfiguration _configuration;
    public TokenServices(IBaseRepository<Role> rolerepo, IBaseRepository<User> userrepo, Sk_productContext context, IBaseRepository<UserRole> urolerepo,IConfiguration configuration)
    {
      _rolerepo = rolerepo;
      _userrepo = userrepo;
      _context = context;
      _urolerepo = urolerepo;
      _configuration = configuration;
    }

    public string GetToken(User user)
    {
    
      var role = _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefault().RoleId;
      var rolename = _context.Roles.Where(x => x.Id == role).FirstOrDefault().Name;
      var Identity = new ClaimsIdentity(new Claim[] {
             new Claim(ClaimTypes.Role, rolename),
              new Claim(ClaimTypes.Name,$"{user.Name}")
            });

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = Identity,
        Expires = DateTime.Now.AddDays(1),
        Audience = _configuration["Jwt:Audience"],
        Issuer = _configuration["Jwt:Issuer"],
        SigningCredentials = creds
      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return new JwtSecurityTokenHandler().WriteToken(token);
    }

  }
}
