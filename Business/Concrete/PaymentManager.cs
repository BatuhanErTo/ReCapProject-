using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        ICreditCardService _cardService;
        public PaymentManager(IPaymentDal paymentDal,ICreditCardService cardService)
        {
            _paymentDal = paymentDal;
            _cardService = cardService;
        }

        public IResult Pay(CreditCard creditCard, int customerId, decimal amount)
        {
            var isCardValid = _cardService.Validate(creditCard).Success;
            if (isCardValid)
            {
                if(creditCard.Balance < amount)
                {
                    return new ErrorResult();
                }
                creditCard.Balance -= amount;
                _cardService.Update(creditCard);
                var payment = new Payment
                {
                    Amount = creditCard.Balance,
                    CustomerId = customerId,
                    Date = DateTime.Now
                };
                _paymentDal.Add(payment);
                return new SuccessResult("İşlem tamamlandı");
            }
            return new ErrorResult("Geçersiz Kart");
        }
    }
}
