using Common;
using Core.sysTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysLicence
    {
        private static readonly Lazy<callSysLicence> lazy = new Lazy<callSysLicence>(() => new callSysLicence());
        public static callSysLicence Instance { get { return lazy.Value; } }
        public callSysLicence()
        {

        }
        public sysReturn getsysLicenceAsDatatable()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

        public sysReturn getsysLicenceAsList()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }


        public sysReturn getsysLicenceWithId(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }


        public sysReturn insertsysLicence(sysLicence local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

        public sysReturn updatesysLicence(sysLicence local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

        public sysReturn deletesysLicence(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

    }
}
