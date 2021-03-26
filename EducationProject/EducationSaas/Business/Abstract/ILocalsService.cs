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
        IDataResult<List<Locals>> GetList();
        IDataResult<Locals> GetById(int locals);
        IResult Add(Locals locals);
        IResult Delete(Locals locals);
        IResult Update(Locals locals);
    }
}
