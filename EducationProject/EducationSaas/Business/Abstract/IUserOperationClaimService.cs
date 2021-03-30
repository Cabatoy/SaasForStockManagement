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
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetList();
        IDataResult<List<UserOperationClaim>> GetByRoleId(int rolesId);
        IResult Add(UserOperationClaim roles);
        IResult Delete(UserOperationClaim roles);
        IResult Update(UserOperationClaim roles);
    }
}
