using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sk_product.Common.CommonModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
