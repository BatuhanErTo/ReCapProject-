using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length >= 2)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Couldn't add to db");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public Car GetCarsById(int Id)
        {
            return _carDal.Get(p => p.Id == Id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }

}
