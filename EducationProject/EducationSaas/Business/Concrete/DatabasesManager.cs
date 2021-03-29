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
        //kurallar buralara yazilabilir if else vs gibi gibi
        public IResult Add(Database database)
        {
            _databasesDal.Add(database);
            return new SuccessResult(message: Messages.DatabaseAdded);
        }

        public IResult Delete(Database database)
        {
            _databasesDal.Delete(database);
            return new SuccessResult(message: Messages.DatabaseDeleted);
        }

        public IDataResult<Database> GetById(int databaseId)
        {
            return new SuccessDataResult<Database>(_databasesDal.Get(p => p.Id == databaseId));
        }

        public IDataResult<List<Database>> GetList()
        {
            return new SuccessDataResult<List<Database>>(_databasesDal.GetList());
        }

        public IResult Update(Database database)
        {
            _databasesDal.Update(database);
            return new SuccessResult(message: Messages.DatabaseUpdated);
        }
    }
}