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
    public interface ICompanyUserService
    {
        List<CompanyOperationClaim> GetClaims(CompanyUser user);
        IDataResult<List<CompanyUser>> GetUserList();
        IDataResult<CompanyUser> GetUserById(int userId);
        CompanyUser GetByMail(string mail);
        IResult Add(CompanyUser user);
        IResult Delete(CompanyUser user);
        IResult Update(CompanyUser user);

    }
}
