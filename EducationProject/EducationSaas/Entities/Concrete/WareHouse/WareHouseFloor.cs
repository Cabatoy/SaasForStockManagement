using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class WareHouseFloor : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int WareHouseId { get; set; }
        public string FloorName { get; set; }
        public string FloorBarcode { get; set; }
        public bool Deleted { get; set; }
    }
}
