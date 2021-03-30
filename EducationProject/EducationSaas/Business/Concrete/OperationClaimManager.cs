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
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _rolesDal;

        public OperationClaimManager(IOperationClaimDal rolesDal)
        {
            _rolesDal = rolesDal;
        }
        public IResult Add(OperationClaim roles)
        {
            _rolesDal.Add(roles);
            return new SuccessResult(message: Messages.rolesAdded);
        }

        public IResult Delete(OperationClaim roles)
        {
            _rolesDal.Delete(roles);
            return new SuccessResult(message: Messages.rolesDeleted);
        }

        public IDataResult<OperationClaim> GetById(int rolesId)
        {
            return new SuccessDataResult<OperationClaim>(_rolesDal.Get(p => p.Id == rolesId));
        }

        public IDataResult<List<OperationClaim>> GetList()
        {
            return new SuccessDataResult<List<OperationClaim>>(_rolesDal.GetList());
        }

        public IResult Update(OperationClaim roles)
        {
            _rolesDal.Update(roles);
            return new SuccessResult(message: Messages.rolesUpdated);
        }
    }
}
