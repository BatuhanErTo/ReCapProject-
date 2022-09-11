using Core.DataAccess;
using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
    }
}
