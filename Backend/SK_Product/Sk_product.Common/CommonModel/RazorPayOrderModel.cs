using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk_product.Common.CommonModel
{
    public class RazorPayOrderModel
    {
        public decimal GrandTotal { get; set; }
        public string Currency { get; set; }
        public string Receipt { get; set; }
    }
}
