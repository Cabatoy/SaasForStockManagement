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
        public List<sysLocals> lstLocals { get; set; }
        private static readonly Lazy<sysCompany> lazy = new Lazy<sysCompany>(() => new sysCompany());
        public static sysCompany Instance { get { return lazy.Value; } }
        public sysCompany()
        {

        }
    }
   
}
