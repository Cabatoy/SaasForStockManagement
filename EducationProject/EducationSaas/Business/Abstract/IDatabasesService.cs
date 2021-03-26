using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDatabasesService
    {
        IDataResult<List<Databases>> GetList();
        IDataResult<Databases> GetById(int databaseId);
        IResult Add(Databases company);
        IResult Delete(Databases company);
        IResult Update(Databases company);

    }
}
