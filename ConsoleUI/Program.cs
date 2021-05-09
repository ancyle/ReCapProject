using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        //Entity Simulator
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car car = new Car { BrandId = 1, ColorId = 2, DailyPrice = 120.5m, Description = "Corsa B", ModelYear = 2004 };
            //Car car2 = new() { BrandId = 3, ColorId = 5, DailyPrice = 500m, Description = "R35", ModelYear = 2018 };
            //Car car3 = new() { BrandId = 2, ColorId = 3, DailyPrice = 90.250m, Description = "Polo 1.4TDI", ModelYear = 2010 };
            Car car4 = new() { BrandId = 2, ColorId = 3, DailyPrice = 0m, Description = "", ModelYear = 2010 };
            //carManager.Add(car);
            //carManager.Add(car2);
            //carManager.Add(car3);
            carManager.Add(car4);
            Console.ReadKey(true);
        }
    }
}
