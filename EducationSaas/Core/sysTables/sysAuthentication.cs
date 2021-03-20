using System;
using System.Collections.Generic;

namespace Core
{
    public class sysAuthentication
    {
        public int ID { get; set; }
        public string Authentication { get; set; }
    
        

    }

    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysAuthentication
    {
        private static readonly Lazy<callSysAuthentication> lazy = new Lazy<callSysAuthentication>(() => new callSysAuthentication());
        public static callSysAuthentication Instance { get { return lazy.Value; } }
        public callSysAuthentication()
        {

        }

    }

}
