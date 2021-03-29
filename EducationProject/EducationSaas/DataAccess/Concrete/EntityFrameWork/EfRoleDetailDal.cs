using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRoleDetailDal : EfEntityRepositoryBase<RoleDetail, FirstStepContext>, IRoleDetailDal
    {
        public List<RoleDetail> GetRoleDetails(int RoleID)
        {
            using (var context = new FirstStepContext())
            {
                var result = from a in context.Role
                             join b in context.RoleDetail on a.ID equals b.RoleId
                             where a.ID == RoleID
                             select new RoleDetail { Id = b.Id, Description = b.Description };
                return result.ToList();
            }
        }
    }
}
