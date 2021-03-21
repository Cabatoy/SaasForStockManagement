using Core.sysTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysUsers : sysUsers
    {
        private static readonly Lazy<callSysUsers> lazy = new Lazy<callSysUsers>(() => new callSysUsers());
        public static callSysUsers Instance { get { return lazy.Value; } }
        public callSysUsers()
        {

        }


    }
}
