using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IUsersService
    {
        IDataResult<List<Users>> GetList();
        IDataResult<Users> GetById(int userId);
        IResult Add(Users user);
        IResult Delete(Users user);
        IResult Update(Users user);
    }
}
