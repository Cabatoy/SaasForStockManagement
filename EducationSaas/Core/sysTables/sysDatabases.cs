using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public class sysDatabases
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public clsDbProp DbInfo { get; set; }
    
        
        private static readonly Lazy<sysDatabases> lazy = new Lazy<sysDatabases>(() => new sysDatabases());
        public static sysDatabases Instance { get { return lazy.Value; } }
        public sysDatabases()
        {

        }

    }
    public class clsDbProp
    {
        public string DbName { get; set; }
        public string DbPass { get; set; }
        public string DbSunucu { get; set; }
        public string DbUser { get; set; }

    }
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
