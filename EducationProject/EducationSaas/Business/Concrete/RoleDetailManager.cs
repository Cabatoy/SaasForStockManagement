using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RoleDetailManager : IRoleDetailService
    {
        private IRoleDetailDal _roleDetail;

        public RoleDetailManager(IRoleDetailDal roleDetail)
        {
            _roleDetail = roleDetail;
        }

        public IDataResult<List<RoleDetail>> GetByRoleId(int rolesId)
        {
            return new SuccessDataResult<List<RoleDetail>>(_roleDetail.GetList(p => p.RoleId == rolesId));
        }

        public IDataResult<List<RoleDetail>> GetList()
        {
            return new SuccessDataResult<List<RoleDetail>>(_roleDetail.GetList());
        }
    }
}
