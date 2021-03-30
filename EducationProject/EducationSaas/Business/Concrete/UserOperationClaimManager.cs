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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _UserOperationClaim;

        public UserOperationClaimManager(IUserOperationClaimDal UserOperationClaim)
        {
            _UserOperationClaim = UserOperationClaim;
        }

        public IResult Add(UserOperationClaim roles)
        {
            _UserOperationClaim.Add(roles);
            return new SuccessResult(message: Messages.rolesAdded);
        }

        public IResult Delete(UserOperationClaim roles)
        {
            _UserOperationClaim.Delete(roles);
            return new SuccessResult(message: Messages.rolesDeleted);
        }

        public IDataResult<List<UserOperationClaim>> GetByRoleId(int operationClaimId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_UserOperationClaim.GetList(p => p.OperationClaimId == operationClaimId));
        }

        public IDataResult<List<UserOperationClaim>> GetList()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_UserOperationClaim.GetList());
        }

        public IResult Update(UserOperationClaim roles)
        {
            _UserOperationClaim.Update(roles);
            return new SuccessResult(message: Messages.rolesUpdated);
        }
    }
}
