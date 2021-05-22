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
    public class WareHouseShelfManager : IWareHouseShelfService
    {
        private readonly IWareHouseShelfDal _wareHouseShelfDal;
        public WareHouseShelfManager(IWareHouseShelfDal wareHouseShelfDal)
        {
            _wareHouseShelfDal = wareHouseShelfDal;
        }

        public IDataResult<List<WareHouseShelf>> GetShelfList()
        {
            return new DataResult<List<WareHouseShelf>>(_wareHouseShelfDal.GetList(), true);
        }

        public IDataResult<WareHouseShelf> GetShelfById(int shelfId)
        {
            return new DataResult<WareHouseShelf>(_wareHouseShelfDal.Get(x => x.Id == shelfId), true);
        }

        public IDataResult<WareHouseShelf> GetShelfByBarcode(string shelfBarcode)
        {
            return new DataResult<WareHouseShelf>(_wareHouseShelfDal.Get(x => x.ShelfBarcode == shelfBarcode), true);
        }

        public IResult Add(WareHouseShelf shelf)
        {
            _wareHouseShelfDal.Add(shelf);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseShelfAdded);
        }

        public IResult Delete(WareHouseShelf shelf)
        {
            shelf.Deleted = true;
            _wareHouseShelfDal.Update(shelf);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseShelfDeleted);
        }

        public IResult Update(WareHouseShelf shelf)
        {
            _wareHouseShelfDal.Update(shelf);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseShelfUpdated);
        }
    }
}
