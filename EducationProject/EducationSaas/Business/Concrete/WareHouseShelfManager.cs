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
    public class WareHouseShelfManager :IWareHouseShelfService
    {
        private readonly IWareHouseShelfDal _wareHouseShelfDal;
        public WareHouseShelfManager(IWareHouseShelfDal wareHouseShelfDal)
        {
            _wareHouseShelfDal = wareHouseShelfDal;
        }

        public IDataResult<List<WareHouseShelf>> GetList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseShelf> GetById(int shelfId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseShelf> GetByBarcode(int shelfBarcode)
        {
            throw new NotImplementedException();
        }

        public IResult Add(WareHouseShelf shelf)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(WareHouseShelf shelf)
        {
            throw new NotImplementedException();
        }

        public IResult Update(WareHouseShelf shelf)
        {
            throw new NotImplementedException();
        }
    }
}
