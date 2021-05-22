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
        IDataResult<List<WareHouseCorridor>> GetCorridorList();
        IDataResult<WareHouseCorridor> GetCorridorById(int corridorId);
        IDataResult<WareHouseCorridor> GetCorridorByBarcode(string corridorBarcode);
        IResult Add(WareHouseCorridor corridor);
        IResult Delete(WareHouseCorridor corridor);
        IResult Update(WareHouseCorridor corridor);
    }
}
