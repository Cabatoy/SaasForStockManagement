using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RolesManager : IRolesService
    {
        private IRolesDal _rolesDal;

        public RolesManager(IRolesDal rolesDal)
        {
            _rolesDal = rolesDal;
        }
        public IResult Add(Role roles)
        {
            _rolesDal.Add(roles);
            return new SuccessResult(message: Messages.rolesAdded);
        }

        public IResult Delete(Role roles)
        {
            _rolesDal.Delete(roles);
            return new SuccessResult(message: Messages.rolesDeleted);
        }

        public IDataResult<Role> GetById(int rolesId)
        {
            return new SuccessDataResult<Role>(_rolesDal.Get(p => p.ID == rolesId));
        }

        public IDataResult<List<Role>> GetList()
        {
            return new SuccessDataResult<List<Role>>(_rolesDal.GetList());
        }

        public IResult Update(Role roles)
        {
            _rolesDal.Update(roles);
            return new SuccessResult(message: Messages.rolesUpdated);
        }
    }
}
