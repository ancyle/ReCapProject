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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using ReCapContext reCap = new();
            var addedEntry = reCap.Entry(entity);
            addedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            reCap.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            using ReCapContext reCap = new();
            var deletedEntry = reCap.Entry(entity);
            deletedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            reCap.SaveChanges();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using ReCapContext reCap = new();
            return reCap.Set<Brand>().SingleOrDefault(filter);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using ReCapContext reCap = new();
            return filter == null
                ? reCap.Set<Brand>().ToList()
                : reCap.Set<Brand>().Where(filter).ToList();
        }

        public void Update(Brand entity)
        {
            using ReCapContext reCap = new();
            var updatedEntry = reCap.Entry(entity);
            updatedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            reCap.SaveChanges();
        }
    }
}
