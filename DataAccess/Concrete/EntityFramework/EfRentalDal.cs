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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (var context = new ReCapContext())
            {
                var result = from rentals in context.Rentals
                             join customers in context.Customers
                             on rentals.CustomerId equals customers.Id
                             join users in context.Users
                             on customers.UserId equals users.Id
                             join cars in context.Cars
                             on rentals.CarId equals cars.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             select new RentalDetailsDto
                             {
                                 BrandName = brands.Name,
                                 CarName = cars.Name,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 RentDate = rentals.RentDate,
                                 ReturnDate = rentals.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
