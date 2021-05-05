using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyUnit : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int FactorOne { get; set; }
        public int FactorTwo { get; set; }
    }
}
