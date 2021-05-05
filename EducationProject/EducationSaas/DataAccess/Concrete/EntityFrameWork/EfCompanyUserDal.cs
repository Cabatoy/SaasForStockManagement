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
    public class EfCompanyUserDal : EfEntityRepositoryBase<CompanyUser, FirstStepContext>, ICompanyUserDal
    {
        public List<CompanyOperationClaim> GetClaims(CompanyUser user)
        {
            using var context = new FirstStepContext();
            var result = from operationClaim in context.OperationClaim
                join userOperationClaim in context.UserOperationClaim
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new CompanyOperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
