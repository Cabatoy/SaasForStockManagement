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
    public interface IRoleDetailService
    {
        IDataResult<List<RoleDetail>> GetList();
        IDataResult<List<RoleDetail>> GetByRoleId(int rolesId);
        //IResult Add(RoleDetail roles);
        //IResult Delete(RoleDetail roles);
        //IResult Update(RoleDetail roles);
    }
}
