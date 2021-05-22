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
    public class WareHouseBenchManager : IWareHouseBenchService
    {
        private readonly IWareHouseBenchDal _wareHouseBenchDal;

        public WareHouseBenchManager(IWareHouseBenchDal wareHouseBenchDal)
        {
            _wareHouseBenchDal = wareHouseBenchDal;
        }

        public IDataResult<List<WareHouseBench>> GetBenchList()
        {
            return new DataResult<List<WareHouseBench>>(_wareHouseBenchDal.GetList(), true);
        }

        public IDataResult<WareHouseBench> GetBenchById(int BenchId)
        {
            return new DataResult<WareHouseBench>(_wareHouseBenchDal.Get(x => x.Id == BenchId), true);
        }

        public IDataResult<WareHouseBench> GetByBarcode(string BenchBarcode)
        {
            return new DataResult<WareHouseBench>(_wareHouseBenchDal.Get(x => x.BenchBarcode == BenchBarcode), true);
        }

        public IResult Add(WareHouseBench Bench)
        {
            _wareHouseBenchDal.Update(Bench);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseBenchAdded);
        }

        public IResult Delete(WareHouseBench Bench)
        {
            Bench.Deleted = true;
            _wareHouseBenchDal.Update(Bench);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseBenchDeleted);
        }

        public IResult Update(WareHouseBench Bench)
        {
            _wareHouseBenchDal.Update(Bench);
            return new DataResult<WareHouseFloor>(message: Messages.WareHouseBenchUpdated);
        }
    }
}
