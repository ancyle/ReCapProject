using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //Entity Simulator
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach(var item in carManager.GetAll())
            {
                Console.WriteLine("{0} Model: {1} Price: {2}$",item.Description,item.ModelYear,item.DailyPrice);
            }
            Console.ReadKey(true);
        }
    }
}
