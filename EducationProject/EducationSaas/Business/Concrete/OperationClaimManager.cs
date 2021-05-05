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
        public IResult Add(CompanyOperationClaim roles)
        {
            _rolesDal.Add(roles);
            return new SuccessResult(message: Messages.rolesAdded);
        }

        public IResult Delete(CompanyOperationClaim roles)
        {
            _rolesDal.Delete(roles);
            return new SuccessResult(message: Messages.rolesDeleted);
        }

        public IDataResult<CompanyOperationClaim> GetById(int rolesId)
        {
            return new SuccessDataResult<CompanyOperationClaim>(_rolesDal.Get(p => p.Id == rolesId));
        }

        public IDataResult<List<CompanyOperationClaim>> GetList()
        {
            return new SuccessDataResult<List<CompanyOperationClaim>>(_rolesDal.GetList());
        }

        public IResult Update(CompanyOperationClaim roles)
        {
            _rolesDal.Update(roles);
            return new SuccessResult(message: Messages.rolesUpdated);
        }
    }
}
