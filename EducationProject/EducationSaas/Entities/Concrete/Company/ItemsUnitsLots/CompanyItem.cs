using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyItem :IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }

        public string ShortName { get; set; }
        public string Barcode { get; set; }

        public string BarcodeTwo { get; set; }
        public string Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }
        public bool Deleted { get; set; }
    }
}
