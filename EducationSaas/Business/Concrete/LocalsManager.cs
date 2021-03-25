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

        public IResult Add(Locals locals)
        {
            _localdal.Add(locals);
            return new SuccessResult(message: Messages.LocalsAdded);
        }

        public IResult Delete(Locals locals)
        {
            _localdal.Delete(locals);
            return new SuccessResult(message: Messages.LocalsDeleted);
        }

        public IDataResult<Locals> GetById(int localId)
        {
            return new SuccessDataResult<Locals>(_localdal.Get(p => p.Id == localId));
        }

        public IDataResult<List<Locals>> GetList()
        {
            return new SuccessDataResult<List<Locals>>(_localdal.GetList());
        }

        public IResult Update(Locals locals)
        {
            _localdal.Add(locals);
            return new SuccessResult(message: Messages.LocalsUpdated);
        }
    }
}
