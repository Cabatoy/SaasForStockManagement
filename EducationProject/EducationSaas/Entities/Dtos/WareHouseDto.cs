using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class WareHouseDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<WareHouseFloor> ListOfFloor { get; set; }
        public List<WareHouseCorridor> ListOfCorridor { get; set; }
        public List<WareHouseShelf> ListOfShelf { get; set; }
        public List<WareHouseBench> ListOfBench { get; set; }
    }
}
