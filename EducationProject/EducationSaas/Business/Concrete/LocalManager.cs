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
    public class LocalManager : ILocalService
    {
        private readonly ILocalDal _localDal;

        public LocalManager(ILocalDal localService)
        {
            _localDal = localService;
        }

        public IResult Add(Local local)
        {
            _localDal.Add(local);
            return new SuccessResult(message: Messages.LocalsAdded);
        }

        public IResult Delete(Local local)
        {
            _localDal.Update(PrepareForDelete(local));
            return new SuccessResult(message: Messages.LocalsDeleted);
        }

        private static Local PrepareForDelete(Local local)
        {
            if (local.Deleted)
            {
                return local;
            }
            return local;
        }
        public IDataResult<List<Local>> GetList(int companyId)
        {
            return new SuccessDataResult<List<Local>>(_localDal.GetList(x => x.CompanyId == companyId));
        }

        public IResult Update(Local local)
        {
            _localDal.Update(local);
            return new SuccessResult(message: Messages.LocalsUpdated);
        }

        public IDataResult<List<Local>> GetList()
        {
            return new SuccessDataResult<List<Local>>(_localDal.GetList());
        }
    }
}
