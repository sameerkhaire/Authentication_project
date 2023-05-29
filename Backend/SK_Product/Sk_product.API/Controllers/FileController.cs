using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk_product.API.Helper;

namespace Sk_product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FileController : ControllerBase
  {
    public static IConfiguration _config;
    public FileController(IConfiguration  config)
    {
      _config = config;
    }
    [HttpPost("myfile")]
    public  string post()
    {
      try
      {
        var formCollection = Request.ReadFormAsync().Result;
        var file = formCollection.Files.First();
        if (file.Length > 0)
        {
          string path = _config["uploadfile:key"];
          if(Directory.Exists(path))
          {
            Directory.CreateDirectory(path);
          }
          using(FileStream fileStream = System.IO.File.Create(path+ file.FileName))
          {
            file.CopyTo(fileStream);
            fileStream.Flush();
            return "uploaded";
          }
        }
        return "Bad Request Not uploaded";
      }
      catch(Exception)
      {
        return "Bad Request";
      }
    }
  }
}
