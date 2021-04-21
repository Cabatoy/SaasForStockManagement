using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class UserForRegisterDto : IDto, IEntity
    {
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Adress { get; set; }

        public UserForRegisterDto()
        {
            CompanyId = 0;
            LocalId = 0;
        }
    }

}
