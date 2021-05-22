using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class CompanyItemUnit : IEntity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public bool Deleted { get; set; }
    }
}
