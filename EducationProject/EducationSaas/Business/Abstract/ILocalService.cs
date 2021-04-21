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
  public  interface ILocalService 
    {
        IResult Add(Local user);
        IResult Delete(Local user);
        IResult Update(Local user);

        IDataResult<List<Local>> GetList();
    }
}
