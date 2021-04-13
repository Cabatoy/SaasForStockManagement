using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;

using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autfac.Transaction;
using Core.CrossCuttingConcern.Validation;
using Core.Aspect.Autfac.Validation;
using Core.Aspect.Autofac.Caching;

namespace Business.Concrete
{

    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [ValidatonAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        [CasheRemoveAspect("ICompanyService.Get()")] //getlist ile daha once cache a alinmis veriyi siler daha dogrusu ICompanyService.Get iceren her boku siler
        public IResult Add(Company company)
        {
            // ValidationTool.Validate(new CompanyValidator(), company);
            _companyDal.Add(company);
            return new SuccessResult(message: Messages.CompanyAdded);
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(message: Messages.CompanyDeleted);
        }

        public IDataResult<Company> GetById(int CompanyId)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(filter: p => p.Id == CompanyId));
        }

        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        public IDataResult<List<Company>> GetList()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetList());
        }



        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(message: Messages.CompanyUpdated);
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Company company)
        {
            _companyDal.Update(company);
            _companyDal.Add(company);
            return new SuccessResult(message: "test");
        }
    }
}
