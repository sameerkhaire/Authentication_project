using System.Text;

namespace Sk_product.API.Helper
{
  public class PasswordHasher
  {
    //private static RSACryptoServiceProvider rng = new RSACryptoServiceProvider();
    //private static readonly int saltsize = 16;
    //private static readonly int Hashsize = 20;
    //private static readonly int iteration = 10000;
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
    public static string DecryptedPassword(string password)
    {
      if (string.IsNullOrEmpty(password))
      {
        return null;
      }
      else
      {
        byte[] encrytedpass = Convert.FromBase64String(password);
        string descryptedpass = ASCIIEncoding.ASCII.GetString(encrytedpass);
        return descryptedpass;
      }
    }
  }
}
