using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysDatabases
    {
        private static readonly Lazy<callSysDatabases> lazy = new Lazy<callSysDatabases>(() => new callSysDatabases());
        public static callSysDatabases Instance { get { return lazy.Value; } }
        public callSysDatabases()
        {

        }


    }

}
