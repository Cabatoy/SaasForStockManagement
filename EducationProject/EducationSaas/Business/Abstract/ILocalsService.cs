using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILocalsService
    {
        IDataResult<List<Local>> GetList();
        IDataResult<Local> GetById(int locals);
        IResult Add(Local locals);
        IResult Delete(Local locals);
        IResult Update(Local locals);
    }
}
