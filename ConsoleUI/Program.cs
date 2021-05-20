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
        protected Program() { }
        //Entity Simulator
        static void Main(string[] args)
        {
            //RentalManager manager = new(new EfRentalDal());
            //Rental rental1 = new();
            //rental1.CarId = 1;rental1.CustomerId = 1;rental1.RentDate = DateTime.Now;rental1.ReturnDate = null;
            //var result= manager.Add(rental1);
            //if (result.Success)
            //{
            //    manager.Add(rental1);
            //    Console.WriteLine(result.Message);
            //}
            //else Console.WriteLine(result.Message);
        }
    }
}
