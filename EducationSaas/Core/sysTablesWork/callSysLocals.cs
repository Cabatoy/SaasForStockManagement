using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
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
