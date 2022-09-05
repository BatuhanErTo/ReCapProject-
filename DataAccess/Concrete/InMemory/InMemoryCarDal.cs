using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId = 1,ColorId = 1,DailyPrice = 150,Name="CAR1",Id = 1,ModelYear = 2022},
                new Car{BrandId = 2,ColorId = 2,DailyPrice = 160,Name="CAR2",Id = 2,ModelYear = 2023},
                new Car{BrandId = 3,ColorId = 3,DailyPrice = 170,Name="CAR3",Id = 3,ModelYear = 2024}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(x => x.Id == Id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpDate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUpDate.DailyPrice = car.DailyPrice;
            carToUpDate.Name = car.Name;
            carToUpDate.ModelYear = car.ModelYear;
            carToUpDate.ColorId = car.ColorId;
            carToUpDate.BrandId = car.BrandId;
        }
    }
}
