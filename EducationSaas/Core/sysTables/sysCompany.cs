using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public class sysCompany
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string TaxNumber { get; set; }
        public List<sysLocals> lstLocals { get; set; }
     
    }
   
}
