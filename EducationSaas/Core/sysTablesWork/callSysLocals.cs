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
    public class callSysLocals
    {
        private static readonly Lazy<callSysLocals> lazy = new Lazy<callSysLocals>(() => new callSysLocals());
        public static callSysLocals Instance { get { return lazy.Value; } }
        public callSysLocals()
        {

        }
        public sysReturn getCompanyiesLocalAsDatatable()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn getCompanyiesLocalAsList()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn getAllLocalAsList()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn getAllLocalsAsDataTable()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;
        
        }

        public sysReturn getLocalWithId(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }



        public sysReturn insertLocal(sysLocals local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn updateLocal(sysLocals local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn deleteLocal(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }
    }
}
