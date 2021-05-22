using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWareHouseFloorService
    {
        IDataResult<List<WareHouseFloor>> GetFloorList();
        IDataResult<WareHouseFloor> GetFloorById(int floorId);
        IDataResult<WareHouseFloor> GetFloorByBarcode(string floorBarcode);
        IResult Add(WareHouseFloor floor);
        IResult Delete(WareHouseFloor floor);
        IResult Update(WareHouseFloor floor);
    }
}
