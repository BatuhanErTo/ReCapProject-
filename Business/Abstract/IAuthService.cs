using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLogin userForLogin);
        IDataResult<User> Register(UserForRegister userForRegister);

        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
