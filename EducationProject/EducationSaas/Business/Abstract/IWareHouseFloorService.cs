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
        IDataResult<List<WareHouseFloor>> GetList();
        IDataResult<WareHouseFloor> GetById(int floorId);
        IDataResult<WareHouseFloor> GetByBarcode(int floorBarcode);
        IResult Add(WareHouseFloor floor);
        IResult Delete(WareHouseFloor floor);
        IResult Update(WareHouseFloor floor);
    }
}
