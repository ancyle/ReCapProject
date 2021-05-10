using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> 
        where TEntity:class,IEntity,new() where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using TContext reCap = new();
            var addedEntry = reCap.Entry(entity);
            addedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            reCap.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext reCap = new();
            var deletedEntry = reCap.Entry(entity);
            deletedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            reCap.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext reCap = new();
            return reCap.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext reCap = new();
            return filter == null
                ? reCap.Set<TEntity>().ToList()
                : reCap.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext reCap = new();
            var updatedEntry = reCap.Entry(entity);
            updatedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            reCap.SaveChanges();
        }
    }
}
