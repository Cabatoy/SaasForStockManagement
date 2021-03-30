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
        IDataResult<List<OperationClaim>> GetList();
        IDataResult<OperationClaim> GetById(int rolesId);
        IResult Add(OperationClaim roles);
        IResult Delete(OperationClaim roles);
        IResult Update(OperationClaim roles);
    }
}
