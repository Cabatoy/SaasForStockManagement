using Common;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysAuthentication
    {
        private static readonly Lazy<callSysAuthentication> lazy = new Lazy<callSysAuthentication>(() => new callSysAuthentication());
        public static callSysAuthentication Instance { get { return lazy.Value; } }
        public callSysAuthentication()
        {

        }

        public sysReturn InsertAuth(sysAuthentication aut)
        {
            sysReturn returnValue = new sysReturn();



            return returnValue;
        }

        public sysReturn UpdateAuth(sysAuthentication aut)
        {
            sysReturn returnValue = new sysReturn();



            return returnValue;
        }

        public sysReturn DeleteAuth(int ID)
        {
            sysReturn returnValue = new sysReturn();



            return returnValue;
        }

    }
}
