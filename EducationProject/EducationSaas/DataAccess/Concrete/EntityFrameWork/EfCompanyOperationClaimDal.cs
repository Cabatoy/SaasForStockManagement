using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCompanyOperationClaimDal : EfEntityRepositoryBase<CompanyOperationClaim, FirstStepContext>, ICompanyOperationClaimDal
    {
         
    }
}
