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
        IDataResult<List<Database>> GetList();
        IDataResult<Database> GetById(int databaseId);
        IResult Add(Database company);
        IResult Delete(Database company);
        IResult Update(Database company);

    }
}
