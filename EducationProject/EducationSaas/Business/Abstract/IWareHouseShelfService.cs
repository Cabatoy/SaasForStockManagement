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
        IDataResult<List<WareHouseShelf>> GetList();
        IDataResult<WareHouseShelf> GetById(int shelfId);
        IDataResult<WareHouseShelf> GetByBarcode(int shelfBarcode);

        IResult Add(WareHouseShelf shelf);
        IResult Delete(WareHouseShelf shelf);
        IResult Update(WareHouseShelf shelf);
    }
}
