using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal; 
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Insert(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
        [CacheAspect]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [CacheAspect]
        public User GetByMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            return user;
        }
    }
}
