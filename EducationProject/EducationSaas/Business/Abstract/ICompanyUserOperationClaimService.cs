using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyUserOperationClaimService
    {
        IDataResult<List<CompanyUserOperationClaim>> GetList();
        IDataResult<List<CompanyUserOperationClaim>> GetByRoleId(int rolesId);
        IResult Add(CompanyUserOperationClaim roles);
        IResult Delete(CompanyUserOperationClaim roles);
        IResult Update(CompanyUserOperationClaim roles);
    }
}
