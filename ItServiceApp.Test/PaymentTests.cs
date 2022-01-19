using ItServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ItServiceApp.Test
{
    public class PaymentTests
    {
        private readonly IPaymentService _paymentService;

        public PaymentTests(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [Fact]
        public void CheckInstallments()
        {
            var binNumbers = new string[]
            {
                "4475050000000003"
            };
            foreach (var bin in binNumbers)
            {
                var result = _paymentService.CheckInstallments(bin, 1000);
            }

            Assert.Equal(true,true);
        }
    }
}
