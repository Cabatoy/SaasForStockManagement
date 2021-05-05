using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using ServiceStack;

namespace Entities.Concrete.Offer
{
    public class CompanyOfferHeader : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        

    }
}
