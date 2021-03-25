using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
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
        public IResult Add(Roles roles)
        {
            _rolesDal.Add(roles);
            return new SuccessResult(message: Messages.rolesAdded);
        }

        public IResult Delete(Roles roles)
        {
            _rolesDal.Delete(roles);
            return new SuccessResult(message: Messages.rolesDeleted);
        }

        public IDataResult<Roles> GetById(int rolesId)
        {
            return new SuccessDataResult<Roles>(_rolesDal.Get(p => p.ID == rolesId));
        }

        public IDataResult<List<Roles>> GetList()
        {
            return new SuccessDataResult<List<Roles>>(_rolesDal.GetList());
        }

        public IResult Update(Roles roles)
        {
            _rolesDal.Update(roles);
            return new SuccessResult(message: Messages.rolesUpdated);
        }
    }
}
