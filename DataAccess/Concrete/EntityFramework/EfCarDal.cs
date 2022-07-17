using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                       join b in context.Brands
                       on c.BrandId equals b.Id
                       join k in context.Colors
                       on c.ColorId equals k.Id
                       select new CarDetailsDto {CarId = c.Id,BrandName = b.Name,CarName = c.Name,ColorName = k.Name,DailyPrice = c.DailyPrice};
                return result.ToList();
            }
        }
    }
}
