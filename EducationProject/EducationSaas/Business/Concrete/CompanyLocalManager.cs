using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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

        //[ValidationAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        //[SecuredOperation("Company.List")]
        //[RedisOperation(duration: 10)]
        //[CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        //[LogAspect(typeof(DatabaseLogger))]
        //[PerformanceAspect(interval: 5)]
        //[TransactionScopeAspect]


        public IResult Add(CompanyLocal local)
        {
            _localDal.Add(local);
            return new DataResult<CompanyLocal>(message: Messages.LocalsAdded);
        }

        public IResult Delete(CompanyLocal local)
        {
            _localDal.Update(PrepareForDelete(local));
            //return new DataResult<CompanyLocal>(local,true,message: Messages.LocalsDeleted);
            return new DataResult<CompanyLocal>(message: Messages.LocalsDeleted);
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
            return new DataResult<List<CompanyLocal>>(_localDal.GetList(x => x.CompanyId == companyId), true);
        }

        public IResult Update(CompanyLocal local)
        {
            _localDal.Update(local);
            return new DataResult<CompanyLocal>(message: Messages.LocalsUpdated);
        }

        [CacheAspect(duration: 10)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<CompanyLocal>> GetLocalList()
        {
            return new DataResult<List<CompanyLocal>>(_localDal.GetList(), true);
        }

        public IDataResult<CompanyLocal> GetLocalByID(int localId)
        {
            return new DataResult<CompanyLocal>(_localDal.Get(filter: p => p.Id == localId), true);
        }
    }
}
