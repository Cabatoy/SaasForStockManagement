﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Order
{
    public class CompanyOrderHeader : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
    }
}