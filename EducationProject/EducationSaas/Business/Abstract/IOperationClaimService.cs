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
    public interface IOperationClaimService
    {
        IDataResult<List<CompanyOperationClaim>> GetList();
        IDataResult<CompanyOperationClaim> GetById(int rolesId);
        IResult Add(CompanyOperationClaim roles);
        IResult Delete(CompanyOperationClaim roles);
        IResult Update(CompanyOperationClaim roles);
    }
}
