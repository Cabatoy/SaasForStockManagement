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
    public interface IRolesService
    {
        IDataResult<List<Role>> GetList();
        IDataResult<Role> GetById(int rolesId);
        IResult Add(Role roles);
        IResult Delete(Role roles);
        IResult Update(Role roles);
    }
}
