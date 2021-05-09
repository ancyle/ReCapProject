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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using ReCapContext reCap = new();
            var addedEntry = reCap.Entry(entity);
            addedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            reCap.SaveChanges();
        }

        public void Delete(Color entity)
        {
            using ReCapContext reCap = new();
            var deletedEntry = reCap.Entry(entity);
            deletedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            reCap.SaveChanges();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using ReCapContext reCap = new();
            return reCap.Set<Color>().SingleOrDefault(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using ReCapContext reCap = new();
            return filter == null
                ? reCap.Set<Color>().ToList()
                : reCap.Set<Color>().Where(filter).ToList();
        }

        public void Update(Color entity)
        {
            using ReCapContext reCap = new();
            var updatedEntry = reCap.Entry(entity);
            updatedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            reCap.SaveChanges();
        }
    }
}
