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
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                       join b in context.Brands
                       on c.BrandId equals b.Id
                       join k in context.Colors
                       on c.ColorId equals k.Id
                       select new CarDetailsDto {
                           CarId = c.Id,
                           BrandId = b.Id,
                           BrandName = b.Name,
                           CarName = c.Name,
                           ColorId = k.Id,
                           ColorName = k.Name,
                           DailyPrice = c.DailyPrice,
                           Description = c.Description,
                           ModelYear = c.ModelYear,
                           CarImage = ((from ci in context.CarImages
                                        where (c.Id == ci.CarId)
                                        select new CarImage
                                        {
                                            Id = ci.Id,
                                            CarId = ci.CarId,
                                            Date = ci.Date,
                                            ImagePath = ci.ImagePath
                                        }).ToList()).Count == 0
                                                    ? new List<CarImage> { new CarImage { Id = -1, CarId = c.Id, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" } }
                                                    : (from ci in context.CarImages
                                                       where (c.Id == ci.CarId)
                                                       select new CarImage
                                                       {
                                                           Id = ci.Id,
                                                           CarId = ci.CarId,
                                                           Date = ci.Date,
                                                           ImagePath = ci.ImagePath
                                                       }).ToList()
                       };
                return filter == null ? result.ToList():result.Where(filter).ToList();
            }
        }
    }
}
