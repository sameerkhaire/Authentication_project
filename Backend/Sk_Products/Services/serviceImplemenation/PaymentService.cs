using CommonEntity;
using DAL.Models;
using Microsoft.Extensions.Options;
using Razorpay.Api;
using Repositories.Interface;
using Repositories.IRepository;
using Services.Implementations;
using Services.Interfaces;
using Services.serviceImplemenation;
using Services.ServiceInterface;
using System.Security.Cryptography;
using System.Text;

namespace Services.serviceImplemenation
{
    //https://razorpay.com/integrations/
    //https://razorpay.com/docs/payment-gateway/web-integration/standard/
    public class PaymentService : Service<PaymentDetail>, IPaymentService
    {
        private readonly IOptions<RazorPayConfig> _razorPayConfig;
        private readonly RazorpayClient _client;
        IBaseRepo<PaymentDetail> _paymentRepo;
        ICartRepository _cartRepo;
        public PaymentService(IOptions<RazorPayConfig> razorPayConfig, IBaseRepo<PaymentDetail> paymentRepo, ICartRepository cartRepo) : base(paymentRepo)
        {
            _razorPayConfig = razorPayConfig;
            _paymentRepo = paymentRepo;
            _cartRepo = cartRepo;
            if (_client == null)
            {
                _client = new RazorpayClient(_razorPayConfig.Value.Key, _razorPayConfig.Value.Secret);
            }
        }
        public string CreateOrder(decimal amount, string currency, string receipt)
        {
            try
            {
                Dictionary<string, object> options = new Dictionary<string, object>();

                options.Add("amount", amount);
                options.Add("currency", currency);
                options.Add("receipt", receipt);
                options.Add("payment_capture", 1);
                Razorpay.Api.Order orderResponse = _client.Order.Create(options);
                return orderResponse["id"].ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Payment GetPaymentDetails(string paymentId)
        {
            if (!String.IsNullOrWhiteSpace(paymentId))
            {
                return _client.Payment.Fetch(paymentId);
            }
            return null;
        }

        public bool VerifySignature(string signature, string orderId, string paymentId)
        {
            string payload = string.Format("{0}|{1}", orderId, paymentId);
            string secret = RazorpayClient.Secret;
            string actualSignature = getActualSignature(payload, secret);
            return actualSignature.Equals(signature);
        }

        private static string getActualSignature(string payload, string secret)
        {
            byte[] secretBytes = StringEncode(secret);
            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);
            var bytes = StringEncode(payload);

            return HashEncode(hashHmac.ComputeHash(bytes));
        }

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        public int SavePaymentDetails(PaymentDetail model)
        {
            _paymentRepo.Add(model);
            var cart = _cartRepo.Find(model.CartId);
            cart.IsActive = false;
            return _paymentRepo.SaveChanges();
        }
    }
}
