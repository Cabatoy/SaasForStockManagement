using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWareHouseCorridorService
    {
        IDataResult<List<WareHouseCorridor>> GetList();
        IDataResult<WareHouseCorridor> GetById(int corridorId);
        IDataResult<WareHouseCorridor> GetByBarcode(int corridorBarcode);
        IResult Add(WareHouseCorridor corridor);
        IResult Delete(WareHouseCorridor corridor);
        IResult Update(WareHouseCorridor corridor);
    }
}
