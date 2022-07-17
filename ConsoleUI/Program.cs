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
            //CarTest(); 
            //BrandTest(); => it passed all of the test
            //ColorTest(); => it passed all of the test
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetCarsDetails();
            foreach (var car in cars)
            {
                Console.WriteLine(car.CarName+" "+car.BrandName+" "+car.ColorName+" "+car.DailyPrice);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color
            {
                Name = "Black",
                Id = 1
            };
            Color color2 = new Color
            {
                Name = "DarkRed",
                Id = 2
            };
            colorManager.Update(color2);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand
            {
                Name = "Mercedes",
                Id = 1,
            };
            Brand brand2 = new Brand
            {
                Name = "Renault",
                Id = 2,
            };
            brandManager.Update(brand2);    
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                BrandId = 1,
                ColorId = 1,
                Id = 1,
                Name = "AMG",
                DailyPrice = 1,
                ModelYear = 1
            };
            Car car2 = new Car
            {
                BrandId = 1,
                ColorId = 2,
                Id = 2,
                Name = "-X",
                DailyPrice = 1,
                ModelYear = 1
            };
            carManager.Update(car2);
        }
    }
}
