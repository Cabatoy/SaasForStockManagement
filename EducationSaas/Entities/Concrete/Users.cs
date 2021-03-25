﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
    }
}
