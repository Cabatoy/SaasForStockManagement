using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WareHouseBench : IEntity
    {
        public int Id { get; set; }
      
        public int ShelfId { get; set; }
        public string ShelfName { get; set; }
        public string ShelfBarcode { get; set; }
    }
}
