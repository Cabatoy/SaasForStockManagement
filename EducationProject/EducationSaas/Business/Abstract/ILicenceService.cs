using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILicenceService
    {
        IDataResult<List<Licence>> GetList();
        IDataResult<Licence> GetById(int licenceId);
        IResult Add(Licence licence);
        IResult Delete(Licence licence);
        IResult Update(Licence licence);
    }
}
