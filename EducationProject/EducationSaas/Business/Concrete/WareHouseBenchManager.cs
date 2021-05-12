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
    public class WareHouseBenchManager : IWareHouseBenchService
    {
        private readonly IWareHouseBenchDal _wareHouseBenchDal;

        public WareHouseBenchManager(IWareHouseBenchDal wareHouseBenchDal)
        {
            _wareHouseBenchDal = wareHouseBenchDal;
        }

        public IDataResult<List<WareHouseBench>> GetList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseBench> GetById(int BenchId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<WareHouseBench> GetByBarcode(int BenchBarcode)
        {
            throw new NotImplementedException();
        }

        public IResult Add(WareHouseBench Bench)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(WareHouseBench Bench)
        {
            throw new NotImplementedException();
        }

        public IResult Update(WareHouseBench Bench)
        {
            throw new NotImplementedException();
        }
    }
}
