using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete
{
    public class CompanyWareHouseManager : ICompanyWareHouseService
    {
        private readonly ICompanyWareHouseDal _companyWareHouseDal;
        private readonly IWareHouseCorridorDal _wareHouseCorridorDal;
        private readonly IWareHouseFloorDal _wareHouseFloorDal;
        private readonly IWareHouseShelfDal _wareHouseShelfDal;
        private readonly IWareHouseBenchDal _wareHouseBenchDal;
        public CompanyWareHouseManager(ICompanyWareHouseDal companyWareHouseDal, IWareHouseCorridorDal wareHouseCorridorDal, IWareHouseFloorDal wareHouseFloorDal, IWareHouseShelfDal wareHouseShelfDal, IWareHouseBenchDal wareHouseBenchDal)
        {
            _companyWareHouseDal = companyWareHouseDal;
            _wareHouseCorridorDal = wareHouseCorridorDal;
            _wareHouseFloorDal = wareHouseFloorDal;
            _wareHouseShelfDal = wareHouseShelfDal;
            _wareHouseBenchDal = wareHouseBenchDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(CompanyWareHouse wareHouse)
        {
            _companyWareHouseDal.Add(wareHouse);
            GetWareHouseList();
            return new DataResult<CompanyWareHouse>(Messages.WareHouseAdded);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(CompanyWareHouse wareHouse)
        {
            wareHouse.Deleted = true;
            _companyWareHouseDal.Update(wareHouse);
            GetWareHouseList();
            return new DataResult<CompanyWareHouse>(Messages.WareHouseDeleted);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [PerformanceAspect(interval: 0)]
        public IDataResult<WareHouseDto> GetWareHouseById(int wareHouseId)
        {
            WareHouseDto dtos = new WareHouseDto();
            var result = new DataResult<CompanyWareHouse>(_companyWareHouseDal.Get(filter: x => x.Id == wareHouseId), true);
            if (result.Success)
            {
                dtos.FullName = result.Data.FullName;

                if (result.Data.WithAdress)
                {
                    dtos.ListOfFloor = new List<WareHouseFloor>();
                    dtos.ListOfCorridor = new List<WareHouseCorridor>();
                    dtos.ListOfShelf = new List<WareHouseShelf>();
                    dtos.ListOfBench = new List<WareHouseBench>();

                   
                    var floorList = _wareHouseFloorDal.GetList(x => x.WareHouseId == wareHouseId);
                    floorList.ForEach(x=> dtos.ListOfFloor.Add(x));
                    dtos.ListOfFloor.ForEach(y => _wareHouseCorridorDal.GetList(x => x.FloorId == y.Id).
                        ForEach(z => dtos.ListOfCorridor.Add(z)));
                    dtos.ListOfCorridor.ForEach(x =>
                        _wareHouseShelfDal.GetList(y => y.CorridorId == x.Id).ForEach(z => dtos.ListOfShelf.Add(z)));
                    dtos.ListOfShelf.ForEach(x => _wareHouseBenchDal.GetList(y => y.ShelfId == x.Id).ForEach(z => dtos.ListOfBench.Add(z)));
                  
                    //linq ile yazilmis ust satirin acik hali commentlendi. 
                    #region not linq

                    //foreach (var floor in floorList)
                    //{
                    //    dtos.ListOfFloor.Add(new WareHouseFloor()
                    //    {
                    //        CompanyId = floor.CompanyId,
                    //        Id = floor.Id,
                    //        WareHouseId= floor.WareHouseId,
                    //        Deleted = floor.Deleted,
                    //        FloorBarcode = floor.FloorBarcode,
                    //        FloorName = floor.FloorName
                    //    });
                    //    foreach (var corridor in _wareHouseCorridorDal.GetList(x => x.FloorId == floor.Id))
                    //    {
                    //        dtos.ListOfCorridor.Add(new WareHouseCorridor()
                    //        {
                    //            FloorId = floor.Id,
                    //            Deleted = corridor.Deleted,
                    //            CorridorBarcode = corridor.CorridorBarcode,
                    //            CorridorName = corridor.CorridorName,
                    //            Id = corridor.Id
                    //        });
                    //        foreach (var shelf in _wareHouseShelfDal.GetList(y => y.CorridorId == corridor.Id))
                    //        {
                    //            dtos.ListOfShelf.Add(new WareHouseShelf()
                    //            {
                    //                Deleted = shelf.Deleted,
                    //                Id = shelf.Id,
                    //                ShelfBarcode = shelf.ShelfBarcode,
                    //                CorridorId = corridor.Id,
                    //                ShelfName = shelf.ShelfName

                    //            });
                    //            foreach (var bench in _wareHouseBenchDal.GetList(y => y.ShelfId == shelf.Id))
                    //            {
                    //                dtos.ListOfBench.Add(new WareHouseBench()
                    //                {
                    //                    Deleted = bench.Deleted,
                    //                    ShelfId = shelf.Id,
                    //                    BenchBarcode = bench.BenchBarcode,
                    //                    BenchName = bench.BenchName,
                    //                    Id = bench.Id
                    //                });
                    //            }
                    //        }

                    //    }
                    //}

                    #endregion


                }

            }
            return new DataResult<WareHouseDto>(dtos, true);
        }

        [CacheAspect(duration: 10)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<CompanyWareHouse>> GetWareHouseList()
        {
            return new DataResult<List<CompanyWareHouse>>(_companyWareHouseDal.GetList(), true);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(CompanyWareHouse wareHouse)
        {
            _companyWareHouseDal.Update(wareHouse);
            GetWareHouseList();
            return new DataResult<CompanyWareHouse>(Messages.WareHouseUpdated);
        }
    }
}
