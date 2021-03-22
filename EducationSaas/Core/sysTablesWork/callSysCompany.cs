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
    public class callSysCompany
    {
        private static readonly Lazy<callSysCompany> lazy = new Lazy<callSysCompany>(() => new callSysCompany());
        public static callSysCompany Instance { get { return lazy.Value; } }
        public callSysCompany()
        {

        }


        public sysReturn getCompanyiesAsDatatable()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn getCompanyiesAsList()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }


        public sysReturn getCompanyWithId(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT TOP 1 [Id] ,[FullName] ,[Adress] ,[TaxNumber]  FROM [sys_Company] where Id={id}";

            return SqlDbFunctions.Instance.ExecuteReader(cmd, false);

        }


        public sysReturn insertCompany(sysCompany local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn updateCompany(sysCompany local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn deleteCompany(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

    }
}
