using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    { 
        IResult Insert(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();

        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
