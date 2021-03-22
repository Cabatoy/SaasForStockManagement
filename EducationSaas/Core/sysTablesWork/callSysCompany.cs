﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysCompany
    {
        private static readonly Lazy<callSysCompany> lazy = new Lazy<callSysCompany>(() => new callSysCompany());
        public static callSysCompany Instance { get { return lazy.Value; } }
        public callSysCompany()
        {

        }
    }
}