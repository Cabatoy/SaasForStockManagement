using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Comment("Id pk, companyId Fk")]
    public class CompanyCustomer : IEntity
    {
        public int Id { get; set; } 
        public int CompanyId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string PhoneNumberOne { get; set; }
        public string PhoneNumberTwo { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }
    }
}
