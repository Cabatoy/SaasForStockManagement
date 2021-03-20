using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public class sysLocals
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }
        public string FullName { get; set; }


        private static readonly Lazy<sysLocals> lazy = new Lazy<sysLocals>(() => new sysLocals());
        public static sysLocals Instance { get { return lazy.Value; } }
        public sysLocals()
        {

        }
    }
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysLocals
    {
        private static readonly Lazy<callSysLocals> lazy = new Lazy<callSysLocals>(() => new callSysLocals());
        public static callSysLocals Instance { get { return lazy.Value; } }
        public callSysLocals()
        {

        }


    }
}
