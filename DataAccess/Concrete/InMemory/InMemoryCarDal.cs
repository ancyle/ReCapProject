using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{Id=1,BrandId=1,ColorId=3,DailyPrice=120.500,Description="Ford Mustang",ModelYear=1965},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=500.000,Description="Nissan R35",ModelYear=2018 },
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=95.000,Description="Opel Corsa B",ModelYear=2015 }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car toDeleteCar = _cars.FirstOrDefault(x => x.Id == car.Id);
            _cars.Remove(toDeleteCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByCategory(int categoryId)
        {
            return _cars.Where(x => x.BrandId == categoryId).ToList();
        }

        public void Update(Car car)
        {
            Car toUpdateCar= _cars.FirstOrDefault(x => x.Id == car.Id);
            toUpdateCar.BrandId = car.BrandId;
            toUpdateCar.ColorId = car.ColorId;
            toUpdateCar.DailyPrice = car.DailyPrice;
            toUpdateCar.Description = car.Description;
            toUpdateCar.ModelYear = car.ModelYear;
        }
    }
}
