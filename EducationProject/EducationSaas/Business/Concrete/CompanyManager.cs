using System;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Business.BusinessAspects.Autofac.Redis;
using Business.BusinessAspects.Redis;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autfac.Transaction;
using Core.Aspect.Autfac.Validation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;

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
        private IRedisCacheService _redisCacheService;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
            _redisCacheService = ServiceTool.ServiceProvider.GetService<IRedisCacheService>();
        }

        [ValidationAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        [CasheRemoveAspect(RedisKeyForList.CompanyList)] //getlist ile daha once cache a alinmis veriyi siler daha dogrusu ICompanyService.Get iceren her boku siler
        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Add(Company company)
        {
            // ValidationTool.Validate(new CompanyValidator(), company);
            IResult result = BusinessRules.Run(CheckCompanyTaxNumberExist(company.TaxNumber));
            if (result != null)
                return result;

            _companyDal.Add(company);
            CompanyListRedisUpdate();
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
            CompanyListRedisUpdate();
            return new DataResult<Company>(message: Messages.CompanyDeleted);
        }

        [LogAspect(typeof(SeqAsyncForwarder))]
        public IDataResult<Company> GetById(int CompanyId)
        {
            return new DataResult<Company>(_companyDal.Get(filter: p => p.Id == CompanyId), true);
        }



        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(SeqAsyncForwarder))]
        [PerformanceAspect(interval: 5)]
        public IDataResult<List<Company>> GetList()
        {
            List<Company> lst = new List<Company>();
            if (_redisCacheService.IsAdd(RedisKeyForList.CompanyList))
                return new DataResult<List<Company>>(_redisCacheService.Get<List<Company>>(RedisKeyForList.CompanyList), true);
            lst = _companyDal.GetList();
            _redisCacheService.Set(RedisKeyForList.CompanyList, lst, TimeSpan.FromHours(1));
            return new DataResult<List<Company>>(_companyDal.GetList(), true);
        }

        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            CompanyListRedisUpdate();
            return new DataResult<Company>(Messages.CompanyUpdated);
        }

        public void CompanyListRedisUpdate()
        {
            _redisCacheService.Remove(RedisKeyForList.CompanyList);
            _redisCacheService.Set(RedisKeyForList.CompanyList, _companyDal.GetList(), TimeSpan.FromHours(1));
        }
    }
}
