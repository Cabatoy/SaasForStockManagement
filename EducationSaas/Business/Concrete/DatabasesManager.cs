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
    class DatabasesManager : IDatabasesService

    {
        private IDatabasesDal _databasesDal;

        public DatabasesManager(IDatabasesDal databasesDal)
        {
            _databasesDal = databasesDal;
        }

        public IResult Add(Databases database)
        {
            //kurallar buralara yazilabilir if else vs gibi gibi
            _databasesDal.Add(database);
            return new SuccessResult(message: Messages.DatabaseAdded);
        }

        public IResult Delete(Databases database)
        {
            _databasesDal.Delete(database);
            return new SuccessResult(message: Messages.DatabaseDeleted);
        }

        public IDataResult<Databases> GetById(int databaseId)
        {
            return new SuccessDataResult<Databases>(_databasesDal.Get(p => p.Id == databaseId));
        }

        public IDataResult<List<Databases>> GetList()
        {
            return new SuccessDataResult<List<Databases>>(_databasesDal.GetList());
        }

        public IResult Update(Databases database)
        {
            _databasesDal.Update(database);
            return new SuccessResult(message: Messages.DatabaseUpdated);
        }
    }
}