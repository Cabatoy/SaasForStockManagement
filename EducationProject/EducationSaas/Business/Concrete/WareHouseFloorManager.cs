using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
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
            _wareHouseFloorDal.Add(floor);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseFloorAdded);
        }

        public IResult Delete(WareHouseFloor floor)
        {
            floor.Deleted = true;
            _wareHouseFloorDal.Update(floor);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseFloorDeleted);
        }

        public IDataResult<WareHouseFloor> GetFloorByBarcode(string floorBarcode)
        {
            return new DataResult<WareHouseFloor>(_wareHouseFloorDal.Get(x => x.FloorBarcode == floorBarcode), true);
        }

        public IDataResult<WareHouseFloor> GetFloorById(int floorId)
        {
            return new DataResult<WareHouseFloor>(_wareHouseFloorDal.Get(x => x.Id == floorId), true);
        }

        public IDataResult<List<WareHouseFloor>> GetFloorList()
        {

            return new DataResult<List<WareHouseFloor>>(_wareHouseFloorDal.GetList(), true);
        }

        public IResult Update(WareHouseFloor floor)
        {
            _wareHouseFloorDal.Update(floor);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseFloorUpdated);
        }
    }
}
