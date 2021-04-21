 using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Company:IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public bool Deleted { get; set; }

    }
}
