using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyLot : IEntity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string LotNo { get; set; }
        public string Barcode { get; set; }

        public string BarcodeTwo { get; set; }
    }
}
