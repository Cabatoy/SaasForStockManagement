using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, FirstStepContext>, IUserOperationClaimDal
    {

        //public List<UserOperationClaim> GetUserOperationClaims(int RoleID)
        //{
        //    using (var context = new FirstStepContext())
        //    {
        //        var result = from a in context.OperationClaims
        //                     join b in context.UserOperationClaims on a.Id equals b.Id
        //                     where a.Id == RoleID
        //                     select new UserOperationClaim { Id = b.Id, RoleName = b.RoleName };
        //        return result.ToList();
        //    }
        //}
    }
}
