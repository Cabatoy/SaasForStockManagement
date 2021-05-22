using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Offer
{
    public class CompanyOfferRow : IEntity
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }

        public bool Deleted { get; set; }
    }
}
