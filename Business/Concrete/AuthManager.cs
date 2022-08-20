using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var isValid = _userService.GetByMail(userForLogin.Email);
            if (isValid == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

        }

        public IDataResult<User> Register(UserForRegister userForRegister)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
