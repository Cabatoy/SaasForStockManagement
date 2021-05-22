using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWareHouseShelfService
    {
        IDataResult<List<WareHouseShelf>> GetShelfList();
        IDataResult<WareHouseShelf> GetShelfById(int shelfId);
        IDataResult<WareHouseShelf> GetShelfByBarcode(string shelfBarcode);

        IResult Add(WareHouseShelf shelf);
        IResult Delete(WareHouseShelf shelf);
        IResult Update(WareHouseShelf shelf);
    }
}
