using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public  class sysUsers
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public sysCompany Company { get; set; }
        public sysLocals Locals { get; set; }
        public sysAuthentication Auth { get; set; }
        public sysLicence Licence { get; set; }
    }
  
}
