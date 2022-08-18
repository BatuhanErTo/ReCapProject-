using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                                on userOperationClaim.Id equals operationClaim.Id
                             where (user.Id == userOperationClaim.Id)
                             select new OperationClaim { Id = operationClaim.Id,Name = operationClaim.Name }; 
                return result.ToList();
            }
        }
    }
}
