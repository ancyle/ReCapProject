using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext> , ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using ReCapContext reCap = new();
            var result = from c in reCap.Cars
                         join co in reCap.Colors on c.ColorId equals co.Id
                         join b in reCap.Brands on c.BrandId equals b.Id
                         select new CarDetailDto
                         {
                             BrandId = b.Id,
                             Id = c.Id,
                             ColorId = co.Id,
                             DailyPrice = c.DailyPrice,
                             Description = c.Description,
                             ModelYear = c.ModelYear,
                             BrandName=b.Name,
                             ColorName=co.Name
                         };
            return result.ToList();
        }
    }
}
