using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRolesService
    {
        IDataResult<List<Roles>> GetList();
        IDataResult<Roles> GetById(int rolesId);
        IResult Add(Roles roles);
        IResult Delete(Roles roles);
        IResult Update(Roles roles);
    }
}
