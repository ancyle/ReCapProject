using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using ReCapContext reCap = new();
            var addedEntry = reCap.Entry(entity);
            addedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            reCap.SaveChanges();
        }

        public void Delete(Car entity)
        {
            using ReCapContext reCap = new();
            var deletedEntry = reCap.Entry(entity);
            deletedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            reCap.SaveChanges();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using ReCapContext reCap = new();
            return reCap.Set<Car>().SingleOrDefault(filter);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using ReCapContext reCap = new();
            return filter == null
                ? reCap.Set<Car>().ToList()
                : reCap.Set<Car>().Where(filter).ToList();
        }

        public void Update(Car entity)
        {
            using ReCapContext reCap = new();
            var updatedEntry = reCap.Entry(entity);
            updatedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            reCap.SaveChanges();
        }
    }
}
