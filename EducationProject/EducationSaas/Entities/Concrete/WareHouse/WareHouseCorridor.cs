using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WareHouseCorridor : IEntity
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string CorridorName { get; set; }
        public string CorridorBarcode { get; set; }
    }
}
