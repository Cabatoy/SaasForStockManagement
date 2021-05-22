using System;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autfac.Transaction;
using Core.Aspect.Autfac.Validation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.IoC;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace Business.Concrete
{

    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        

        private readonly ICacheManager _cacheManager;

        public CompanyManager(ICompanyDal companyDal, ICacheManager cacheManager)
        {
            _companyDal = companyDal;
            _cacheManager = cacheManager;
           
        }

        [ValidationAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Add(Company company)
        {
            // ValidationTool.Validate(new CompanyValidator(), company);
            IResult result = BusinessRules.Run(CheckCompanyTaxNumberExist(company.TaxNumber));
            if (result != null)
                return result;
            _companyDal.Add(company);
            return new DataResult<Company>(Messages.CompanyAdded);
        }

        private IResult CheckCompanyTaxNumberExist(string companyTaxNumber)
        {
            if (_companyDal.GetList(p => p.TaxNumber == companyTaxNumber).Count != 0)
            {
                return new ErrorResult(message: Messages.CompanyTaxNumberExistError);
            }
            return new SuccessResult();
        }

        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
         
            return new DataResult<Company>(message: Messages.CompanyDeleted);
        }


        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);
          
            return new DataResult<Company>(Messages.CompanyUpdated);
        }

        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(SeqAsyncForwarder))]
        [PerformanceAspect(interval: 5)]
        public IDataResult<List<Company>> GetCompanyList()
        {
            return new DataResult<List<Company>>(_companyDal.GetList(), true);
        }
        [LogAspect(typeof(SeqAsyncForwarder))]
        public IDataResult<Company> GetCompanyById(int CompanyId)
        {
            return new DataResult<Company>(_companyDal.Get(filter: p => p.Id == CompanyId), true);
        }
    }
}
