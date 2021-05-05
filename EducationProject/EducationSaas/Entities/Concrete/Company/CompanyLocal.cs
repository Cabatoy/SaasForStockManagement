using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class CompanyLocal : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        public string FullName { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }
    }
}
