using Core.DataAccess;
using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();
        List<CarDetailsDto> GetCarDetailsByBrandId(int brandId);
        List<CarDetailsDto> GetCarDetailsByColorId(int colorId);
    }
}
