using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities.Concrete
{
    public class CompanyOperationClaim : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
