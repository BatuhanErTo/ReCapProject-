using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCar;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCar = creditCard;
        }
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard creditCard)
        {
            BusinessRules.Run(IsCardAlreadyExist(creditCard.Id));
           _creditCar.Add(creditCard);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCar.Delete(creditCard);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
           return new SuccessDataResult<List<CreditCard>>(_creditCar.GetAll());
        }
        [CacheAspect]
        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCar.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Update(CreditCard creditCard)
        {
            BusinessRules.Run(IsCardAlreadyExist(creditCard.Id));
            _creditCar.Update(creditCard);
            return new SuccessResult();
        }

        public IResult Validate(CreditCard creditCard)
        {
            var result = CheckIsValid(creditCard);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult CheckIsValid(CreditCard creditCard)
        {
            var checkCreditCard = _creditCar.Get(c => c.CardNumber == creditCard.CardNumber &&
                c.ExpireMonth == creditCard.ExpireMonth && c.ExpireYear == creditCard.ExpireYear&&
                c.Cvc == creditCard.Cvc&& c.CardHolderFullName == creditCard.CardHolderFullName.ToUpperInvariant());
            if (checkCreditCard != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult IsCardAlreadyExist(int creditCardId)
        {
            var card = GetById(creditCardId).Data;
            if (card == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
