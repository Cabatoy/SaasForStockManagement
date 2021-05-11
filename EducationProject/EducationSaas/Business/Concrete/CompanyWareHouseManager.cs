using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac.Redis;
using Business.BusinessAspects.Redis;
using Business.Constant;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete
{
    public class CompanyWareHouseManager : ICompanyWareHouseService
    {
        private readonly ICompanyWareHouseDal _companyWareHouseDal;
        private readonly IRedisCacheService _redisCacheService;
        public CompanyWareHouseManager(ICompanyWareHouseDal companyWareHouseDal)
        {
            _companyWareHouseDal = companyWareHouseDal;
            _redisCacheService = ServiceTool.ServiceProvider.GetService<IRedisCacheService>();
        }

        //[ValidationAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        //[SecuredOperation("Company.List")]
        //[RedisOperation(duration: 10)]
        //[CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        //[LogAspect(typeof(SeqAsyncForwarder))]
        //[PerformanceAspect(interval: 5)]
        //[TransactionScopeAspect]

        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Add(CompanyWareHouse wareHouse)
        {
            _companyWareHouseDal.Add(wareHouse);
            CompanyWareHouseListRedisUpdate();
            return new DataResult<CompanyWareHouse>(Messages.WareHouseAdded);
        }
        
        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Delete(CompanyWareHouse wareHouse)
        {
            _companyWareHouseDal.Update(wareHouse);
            CompanyWareHouseListRedisUpdate();
            return new DataResult<CompanyWareHouse>(Messages.WareHouseDeleted);
        }
        
        [LogAspect(typeof(SeqAsyncForwarder))]
        public IDataResult<CompanyWareHouse> GetById(int wareHouseId)
        {
            return new DataResult<CompanyWareHouse>(_companyWareHouseDal.Get(filter: x => x.Id == wareHouseId), true);
        }
        
        [LogAspect(typeof(SeqAsyncForwarder))]
        public IDataResult<List<CompanyWareHouse>> GetList()
        {
            List<CompanyWareHouse> lst=new List<CompanyWareHouse>();
            if (_redisCacheService.IsAdd(RedisKeyForList.CompanyWareHouseList))
            {
                lst = _redisCacheService.Get<List<CompanyWareHouse>>(RedisKeyForList.CompanyWareHouseList);
                return new DataResult<List<CompanyWareHouse>>(lst, true);
            }
            lst = _companyWareHouseDal.GetList();
            _redisCacheService.Set(RedisKeyForList.CompanyWareHouseList, lst, TimeSpan.FromHours(1));
            return new DataResult<List<CompanyWareHouse>>(lst, true);
        }

        [LogAspect(typeof(SeqAsyncForwarder))]
        public IResult Update(CompanyWareHouse wareHouse)
        {
            _companyWareHouseDal.Update(wareHouse);
            CompanyWareHouseListRedisUpdate();
            return new DataResult<CompanyWareHouse>(Messages.WareHouseUpdated);
        }


        public void CompanyWareHouseListRedisUpdate()
        {
            _redisCacheService.Remove(RedisKeyForList.CompanyWareHouseList);
            _redisCacheService.Set(RedisKeyForList.CompanyWareHouseList, _companyWareHouseDal.GetList(), TimeSpan.FromHours(1));
        }
    }
}
