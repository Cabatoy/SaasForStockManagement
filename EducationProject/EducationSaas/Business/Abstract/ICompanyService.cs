using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetList();
        IDataResult<Company> GetById(int CompanyId);
        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);

       
    }
}
