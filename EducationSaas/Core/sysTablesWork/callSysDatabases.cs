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
    public class callSysDatabases
    {
        private static readonly Lazy<callSysDatabases> lazy = new Lazy<callSysDatabases>(() => new callSysDatabases());
        public static callSysDatabases Instance { get { return lazy.Value; } }
        public callSysDatabases()
        {

        }
        public sysReturn getDatabasesAsDatatable()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

        public sysReturn getDatabasesAsList()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }


        public sysReturn getDatabasesWithId(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }


        public sysReturn insertDatabases(sysDatabases local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

        public sysReturn updateDatabases(sysDatabases local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }

        public sysReturn deleteDatabases(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        }


    }

}
