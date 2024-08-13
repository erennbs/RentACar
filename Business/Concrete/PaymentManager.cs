using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class PaymentManager : IPaymentService{
        // Fake payment service

        [TransactionScopeAspect]
        public IResult MakePayment(Payment payment) {
            Thread.Sleep(1000);
            // Assuming payment succeeded
            return new SuccessResult("Ödeme Başarılı");
        }
    }
}
