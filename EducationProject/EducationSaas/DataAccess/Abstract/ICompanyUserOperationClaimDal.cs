using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICompanyUserOperationClaimDal : IEntityRepository<CompanyUserOperationClaim>
    {
       // List<UserOperationClaim> GetUserOperationClaims(int RoleID);
    }
}
