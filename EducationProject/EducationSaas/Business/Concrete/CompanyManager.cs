using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autfac.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspect.Autfac.Validation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;

using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Entities.Concrete;


namespace Business.Concrete
{

    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
     

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [ValidationAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        [CasheRemoveAspect("ICompanyService.Get()")] //getlist ile daha once cache a alinmis veriyi siler daha dogrusu ICompanyService.Get iceren her boku siler
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(Company company)
        {
            // ValidationTool.Validate(new CompanyValidator(), company);
            IResult result = BusinessRules.Run(CheckCompanyTaxNumberExist(company.TaxNumber));
            if (result != null)
            {
                return result;
            }
            _companyDal.Add(company);

            return new SuccessResult(message: Messages.CompanyAdded);
        }

        private IResult CheckCompanyTaxNumberExist(string companyTaxNumber)
        {
            if (_companyDal.GetList(p => p.TaxNumber == companyTaxNumber).Count != 0)
            {
                return new ErrorResult(message: Messages.CompanyTaxNumberExistError);
            }
            return new SuccessResult();
        }
     
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(message: Messages.CompanyDeleted);
        }
     
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<Company> GetById(int CompanyId)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(filter: p => p.Id == CompanyId));
        }

        //[SecuredOperation("Company.List")]
        [RedisOperation(duration: 10)]
        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [PerformanceAspect(interval: 5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Company>> GetList()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetList());
        }
       
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(message: Messages.CompanyUpdated);
        }


    }
}
