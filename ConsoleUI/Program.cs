using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 354, Description = "CAR4", Id = 4, ModelYear = 1935 });
            Car car5 = new Car { BrandId = 1, ColorId = 3, DailyPrice = 354, Description = "CAR5", Id = 5, ModelYear = 1935 };
            carManager.Add(car5);
            carManager.Update(new Car { BrandId = 3, ColorId = 4, DailyPrice = 554, Description = "CAR5 But Updated", Id = 5, ModelYear = 1935 });
            foreach (var item in carManager.GetById(5))
            {
                Console.WriteLine(item.Description);
            }

            carManager.Delete(new Car { BrandId = 3, ColorId = 4, DailyPrice = 554, Description = "CAR5 But Updated", Id = 5, ModelYear = 1935 });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
