using Common;
using Common.Db;
using Core;
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
    public class callSysAuthentication
    {
        private static readonly Lazy<callSysAuthentication> lazy = new Lazy<callSysAuthentication>(() => new callSysAuthentication());
        public static callSysAuthentication Instance { get { return lazy.Value; } }

        public callSysAuthentication()
        {
            if (ss == null)
            {
                ss = new SqlDbFunctions();
            }
            //if (SqlDbFunctions.Instance.Server =="" || SqlDbFunctions.Instance.Password == ""|| SqlDbFunctions.Instance.Database == ""|| SqlDbFunctions.Instance.UserName == "")
            //{

            //}
        }
        SqlDbFunctions ss;
        public sysReturn getAuthenticationAsDatatable()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return ss.ExecuteReader(cmd, false);

        }

        public sysReturn getAuthenticationAsList()
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }


        public sysReturn getAuthenticationWithId(int id)
        {

            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }


        public sysReturn insertAuthentication(sysAuthentication local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn updateAuthentication(sysAuthentication local)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";
            return returnValue;

        }

        public sysReturn deleteAuthentication(int id)
        {
            sysReturn returnValue = new sysReturn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "";

            return returnValue;

        }

    }
}
