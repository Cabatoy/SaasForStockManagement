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
    public class LocalsManager : ILocalsService
    {
        private ILocalsDal _localdal;

        public LocalsManager(ILocalsDal localdal)
        {
            _localdal = localdal;
        }

        public IResult Add(Local locals)
        {
            _localdal.Add(locals);
            return new SuccessResult(message: Messages.LocalsAdded);
        }

        public IResult Delete(Local locals)
        {
            _localdal.Delete(locals);
            return new SuccessResult(message: Messages.LocalsDeleted);
        }

        public IDataResult<Local> GetById(int localId)
        {
            return new SuccessDataResult<Local>(_localdal.Get(p => p.Id == localId));
        }

        public IDataResult<List<Local>> GetList()
        {
            return new SuccessDataResult<List<Local>>(_localdal.GetList());
        }

        public IResult Update(Local locals)
        {
            _localdal.Add(locals);
            return new SuccessResult(message: Messages.LocalsUpdated);
        }
    }
}
