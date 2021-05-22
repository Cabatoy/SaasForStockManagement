using System;
using System.Collections.Generic;

using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class WareHouseCorridorManager : IWareHouseCorridorService
    {
        private readonly IWareHouseCorridorDal _wareHouseCorridorDal;

        public WareHouseCorridorManager(IWareHouseCorridorDal wareHouseCorridorDal)
        {
            _wareHouseCorridorDal = wareHouseCorridorDal;
        }

        public IResult Add(WareHouseCorridor corridor)
        {
            _wareHouseCorridorDal.Update(corridor);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseCorridorAdded);
        }

        public IResult Delete(WareHouseCorridor corridor)
        {
            corridor.Deleted = true;
            _wareHouseCorridorDal.Update(corridor);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseCorridorDeleted);
        }

        public IDataResult<WareHouseCorridor> GetCorridorByBarcode(string corridorBarcode)
        {
            return new DataResult<WareHouseCorridor>(_wareHouseCorridorDal.Get(x => x.CorridorBarcode == corridorBarcode), true);
        }

        public IDataResult<WareHouseCorridor> GetCorridorById(int corridorId)
        {
            return new DataResult<WareHouseCorridor>(_wareHouseCorridorDal.Get(x => x.Id == corridorId), true);
        }

        public IDataResult<List<WareHouseCorridor>> GetCorridorList()
        {
            return new DataResult<List<WareHouseCorridor>>(_wareHouseCorridorDal.GetList(), true);
        }

        public IResult Update(WareHouseCorridor corridor)
        {
            _wareHouseCorridorDal.Update(corridor);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseCorridorUpdated);
        }
    }
}
