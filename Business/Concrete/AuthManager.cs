using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
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
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var user = _userService.GetByMail(userForLogin.Email);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            var isValidPassword = HashingHelper.VerifyPasswordHash(userForLogin.Password,user.PasswordHash,user.PasswordSalt);
            if (!isValidPassword)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(user,Messages.SuccesfulLogin);

        }

        public IDataResult<User> Register(UserForRegister userForRegister)
        {
            byte[] passwordSalt;
            byte[] passwordHash;
            HashingHelper.CreatePasswordHash(userForRegister.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                Email = userForRegister.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Insert(user);  
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserAlreadyExist);
        }
    }
}
