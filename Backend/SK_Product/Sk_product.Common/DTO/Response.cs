using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.Common.DTO
{
  public class Response
  {
    public Response(HttpStatusCode staus,string message, object results)
    {
        Status = staus.ToString();
        Message = message;
        Result = results;
    }

    public Response(HttpStatusCode badRequest, string v)
    {
      this.badRequest = badRequest;
      this.v = v;
    }

    public string Status;
    public string Message;
    public object Result;
    private HttpStatusCode badRequest;
    private string v;
  }
}
