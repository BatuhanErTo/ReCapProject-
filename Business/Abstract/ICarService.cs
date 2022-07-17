using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //GetById, GetAll, Add, Update, Delete
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByBrandId(int brandId);

        List<CarDetailsDto> GetCarsDetails();
        Car GetCarsById(int Id);
        List<Car> GetAll();
        void Insert(Car car);
        void Update(Car car);
        void Delete(Car car);
    }

}
