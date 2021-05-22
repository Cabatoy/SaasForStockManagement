﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyWareHouse : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string FullName { get; set; }
        public bool WithAdress { get; set; } //default 0
        
        public bool Deleted { get; set; }

        
    }
}
