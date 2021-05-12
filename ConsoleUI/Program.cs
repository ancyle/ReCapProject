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
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine($"Car Brand: {item.BrandName}, Car Description: {item.Description}");
                }
            }
            //Console.WriteLine(result.Message);
        }
    }
}
