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
            CarManager carManager = new(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.BrandName + " " + item.Description + "/" + item.ColorName + "/" + item.DailyPrice + "/" + item.ModelYear);
            }
        }
    }
}
