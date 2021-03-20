using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public class sysLicence
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }

        public int LocalId { get; set; }
        public string GuiForLicence { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        private static readonly Lazy<sysLicence> lazy = new Lazy<sysLicence>(() => new sysLicence());
        public static sysLicence Instance { get { return lazy.Value; } }
        public sysLicence()
        {

        }

    }
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysLicence
    {
        private static readonly Lazy<callSysLicence> lazy = new Lazy<callSysLicence>(() => new callSysLicence());
        public static callSysLicence Instance { get { return lazy.Value; } }
        public callSysLicence()
        {

        }


    }
}
