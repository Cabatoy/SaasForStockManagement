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
    public class CompanyLocalManager : ICompanyLocalService
    {
        private readonly ICompanyLocalDal _localDal;

        public CompanyLocalManager(ICompanyLocalDal localService)
        {
            _localDal = localService;
        }

        public IResult Add(CompanyLocal local)
        {
            _localDal.Add(local);
            return new SuccessResult(message: Messages.LocalsAdded);
        }

        public IResult Delete(CompanyLocal local)
        {
            _localDal.Update(PrepareForDelete(local));
            return new SuccessResult(message: Messages.LocalsDeleted);
        }

        private static CompanyLocal PrepareForDelete(CompanyLocal local)
        {
            if (local.Deleted)
            {
                return local;
            }
            return local;
        }
        public IDataResult<List<CompanyLocal>> GetList(int companyId)
        {
            return new SuccessDataResult<List<CompanyLocal>>(_localDal.GetList(x => x.CompanyId == companyId));
        }

        public IResult Update(CompanyLocal local)
        {
            _localDal.Update(local);
            return new SuccessResult(message: Messages.LocalsUpdated);
        }

        public IDataResult<List<CompanyLocal>> GetList()
        {
            return new SuccessDataResult<List<CompanyLocal>>(_localDal.GetList());
        }
    }
}
