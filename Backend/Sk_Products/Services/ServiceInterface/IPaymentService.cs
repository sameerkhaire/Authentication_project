

using DAL.Models;
using Razorpay.Api;

namespace Services.ServiceInterface
{
    public interface IPaymentService : IService<PaymentDetail>
    {
        string CreateOrder(decimal amount, string currency, string receipt);
        int SavePaymentDetails(PaymentDetail model);
        Payment GetPaymentDetails(string paymentId);
        bool VerifySignature(string signature, string orderId, string paymentId);
    }
}
