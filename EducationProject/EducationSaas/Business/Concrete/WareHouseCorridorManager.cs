using System;
using System.Collections.Generic;

using Business.Abstract;
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
            throw new NotImplementedException();
        }

        public IResult Delete(WareHouseCorridor corridor)
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseCorridor> GetByBarcode(int corridorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseCorridor> GetById(int corridorBarcode)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<WareHouseCorridor>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(WareHouseCorridor corridor)
        {
            throw new NotImplementedException();
        }
    }
}
