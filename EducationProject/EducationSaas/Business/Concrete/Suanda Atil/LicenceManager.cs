using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class LicenceManager : ILicenceService
    {
        private ILicenceDal _licenceDal;


        public LicenceManager(ILicenceDal licenceDal)
        {
            _licenceDal = licenceDal;

        }
        //kurallar buralara yazilabilir if else vs gibi gibi
        public IResult Add(Licence licence)
        {
            _licenceDal.Add(licence);
            return new SuccessResult(message: Messages.LicenceAdded);
        }

        public IResult Delete(Licence licence)
        {
            _licenceDal.Delete(licence);
            return new SuccessResult(message: Messages.LicenceDeleted);
        }

        public IDataResult<Licence> GetById(int licenceId)
        {
            return new SuccessDataResult<Licence>(_licenceDal.Get(p => p.Id == licenceId));
        }

        public IDataResult<List<Licence>> GetList()
        {
            return new SuccessDataResult<List<Licence>>(_licenceDal.GetList());
        }

        public IResult Update(Licence licence)
        {
            _licenceDal.Update(licence);
            return new SuccessResult(message: Messages.LicenceUpdated);
        }
    }
}
