using Sk_product.Common.CommonModel;
using Sk_product.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sk_product.BAL.IServices
{
    public interface IUserServices
    {
    Task<Response> Register(UserSignUpModel userSignUp);

    }
}
