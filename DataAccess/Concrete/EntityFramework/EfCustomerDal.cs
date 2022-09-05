using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
            using (var context = new ReCapContext())
            {
                var result = from customers in context.Customers
                             join users in context.Users
                             on customers.UserId equals users.Id
                             select new CustomerDetailsDto 
                                {CustomerId = users.Id,FirstName = users.FirstName, LastName = users.LastName, CompanyName = customers.CompanyName };
                return result.ToList();
            }
        }
    }
}
