using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //GetById, GetAll, Add, Update, Delete
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<Car> GetCarsById(int Id);
        IDataResult<List<Car>> GetAll();
        IResult Insert(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }

}
