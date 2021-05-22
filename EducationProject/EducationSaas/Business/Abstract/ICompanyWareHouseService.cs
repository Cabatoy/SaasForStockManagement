using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICompanyWareHouseService
    {
        IDataResult<List<CompanyWareHouse>> GetWareHouseList();
        IDataResult<WareHouseDto> GetWareHouseById(int wareHouseId);
        IResult Add(CompanyWareHouse wareHouse);
        IResult Delete(CompanyWareHouse wareHouse);
        IResult Update(CompanyWareHouse wareHouse);
    }
}
