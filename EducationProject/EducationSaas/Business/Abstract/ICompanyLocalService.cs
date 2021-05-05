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
        IResult Add(CompanyLocal user);
        IResult Delete(CompanyLocal user);
        IResult Update(CompanyLocal user);

        IDataResult<List<CompanyLocal>> GetList();
    }
}
