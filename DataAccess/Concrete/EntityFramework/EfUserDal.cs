using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<Core.Entities.Concrete.OperationClaim> GetClaims(User user)
        {
            using var context = new ReCapContext();
            var result = from operationClaims in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaims.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Name = operationClaims.Name, Id = operationClaims.Id };
            return result.ToList();
        }
    }
}
