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
    public class CompanyUserOperationClaimManager : ICompanyUserOperationClaimService
    {
        private ICompanyUserOperationClaimDal _UserOperationClaim;

        public CompanyUserOperationClaimManager(ICompanyUserOperationClaimDal UserOperationClaim)
        {
            _UserOperationClaim = UserOperationClaim;
        }

        public IResult Add(CompanyUserOperationClaim roles)
        {
            _UserOperationClaim.Add(roles);
            return new SuccessResult(message: Messages.rolesAdded);
        }

        public IResult Delete(CompanyUserOperationClaim roles)
        {
            _UserOperationClaim.Delete(roles);
            return new SuccessResult(message: Messages.rolesDeleted);
        }

        public IDataResult<List<CompanyUserOperationClaim>> GetByRoleId(int operationClaimId)
        {
            return new SuccessDataResult<List<CompanyUserOperationClaim>>(_UserOperationClaim.GetList(p => p.OperationClaimId == operationClaimId));
        }

        public IDataResult<List<CompanyUserOperationClaim>> GetList()
        {
            return new SuccessDataResult<List<CompanyUserOperationClaim>>(_UserOperationClaim.GetList());
        }

        public IResult Update(CompanyUserOperationClaim roles)
        {
            _UserOperationClaim.Update(roles);
            return new SuccessResult(message: Messages.rolesUpdated);
        }
    }
}
