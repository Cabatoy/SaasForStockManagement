using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    /// <summary>
    /// Dependency Injection ornegi
    /// </summary>
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        //kurallar buralara yazilabilir if else vs gibi gibi
        public IResult Add(Company company)
        {
            
            _companyDal.Add(company);
            return new SuccessResult(message: Messages.CompanyAdded);
        }

        public IResult Delete(Company company)
        {

            _companyDal.Delete(company);
            return new SuccessResult(message: Messages.CompanyDeleted);
        }

        public IDataResult<Company> GetById(int CompanyId)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(filter: p => p.Id == CompanyId));
        }

        public IDataResult<List<Company>> GetList()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetList());
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(message: Messages.CompanyUpdated);
        }
    }
}
