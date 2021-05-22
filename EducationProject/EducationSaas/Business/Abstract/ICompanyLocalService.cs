using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface ICompanyLocalService 
    {
        IResult Add(CompanyLocal companyLocal);
        IResult Delete(CompanyLocal companyLocal);
        IResult Update(CompanyLocal companyLocal);
        IDataResult<CompanyLocal> GetLocalByID(int localId);
        IDataResult<List<CompanyLocal>> GetLocalList();
    }
}
