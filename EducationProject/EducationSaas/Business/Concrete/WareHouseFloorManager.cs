using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class WareHouseFloorManager : IWareHouseFloorService
    {
        private readonly IWareHouseFloorDal _wareHouseFloorDal;
        public WareHouseFloorManager(IWareHouseFloorDal wareHouseFloorDal)
        {
            _wareHouseFloorDal = wareHouseFloorDal;
        }
        public IResult Add(WareHouseFloor floor)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(WareHouseFloor floor)
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseFloor> GetByBarcode(int floorBarcode)
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseFloor> GetById(int floorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<WareHouseFloor>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(WareHouseFloor floor)
        {
            throw new NotImplementedException();
        }
    }
}
