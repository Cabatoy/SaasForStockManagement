using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWareHouseBenchService
    {
        IDataResult<List<WareHouseBench>> GetList();
        IDataResult<WareHouseBench> GetById(int BenchIdId);
        IDataResult<WareHouseBench> GetByBarcode(int BenchIdBarcode);
        IResult Add(WareHouseBench roles);
        IResult Delete(WareHouseBench roles);
        IResult Update(WareHouseBench roles);
    }
}
