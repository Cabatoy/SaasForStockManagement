using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public abstract class sysUsers
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
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.

    public class CallSysUsers 
    {
        private static readonly Lazy<CallSysUsers> lazy = new Lazy<CallSysUsers>(() => new CallSysUsers());
        public static CallSysUsers Instance { get { return lazy.Value; } }
        public CallSysUsers()
        {

        }


    }
}
