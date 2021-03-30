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
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetList();
        IDataResult<User> GetById(int userId);
        User GetByMail(string mail);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

    }
}
