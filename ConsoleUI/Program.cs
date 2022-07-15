using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                BrandId = 1,
                ColorId = 1,
                Id = 1,
                Name = "BD",
                DailyPrice = 1,
                ModelYear = 1
            };
            carManager.Add(car);

        }
    }
}
