using Common;
using Common.Db;
using Core.sysTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstStep.sysTablesWork
{
    //tanimlanana siniflar ilgili sql sorgulariyla calisilacak alanlar bu ornekteki gibi tanimlanmalidir
    //bu alanlarda ki islemler mutlak tablo degisitiklikleri sonrasinda gozden gecirilmelidir.
    public class callSysUsers : sysUsers
    {
        private static readonly Lazy<callSysUsers> lazy = new Lazy<callSysUsers>(() => new callSysUsers());
        public static callSysUsers Instance { get { return lazy.Value; } }
        public callSysUsers()
        {

        }


        /// <summary>
        /// sysReturnType altinda value icinde user classi doner
        /// </summary>
        /// <param name="Mail"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public sysReturn userLogin(string Mail, string passWord)
        {
            sysReturn user = new sysReturn();
            sysReturn returnValue = new sysReturn();
            sysUsers uss = new sysUsers();
            SqlCommand cmd = new SqlCommand();
            //string _mail = "";
            string _pass = myCrypto.Instance.SifreUygula(passWord, globalParameters.YardimciVeri);

            cmd.CommandText = string.Format("SELECT top 1 [Id] ,[CompanyId] ,[LocalId] ,[LoginName] ,[PassWord] ,[FullName]  FROM sys__Users where LoginName=@Mail and PassWord=@pass", Mail, _pass);
            cmd.Parameters.AddWithValue("@Mail", Mail);
            cmd.Parameters.AddWithValue("@pass", _pass);
            returnValue = SqlDbFunctions.Instance.ExecuteIdentity(cmd, false);
            DataTable dt = (DataTable)returnValue.Sonuc;
            if (returnValue.Durum == SysWorks.DurumTip.Ok)
            {
                foreach (DataRow item in dt.Rows)
                {
                        uss.ID = item[0]._ToIntegerR();
                        uss.CompanyId = item[0]._ToIntegerR();
                        uss.LocalId = item[0]._ToIntegerR();
                        uss.LoginName = item[0]._ToString();
                        uss.PassWord = passWord;
                        uss.FullName = item[0]._ToString();
                    uss.Company = new sysCompany();
                    uss.Licence = new sysLicence();
                    uss.Locals = new sysLocals();
                }
            }
            returnValue = callSysCompany.Instance.getCompanyWithId(uss.CompanyId);
            if (returnValue.Durum == SysWorks.DurumTip.Ok)
            {
                 dt = (DataTable)returnValue.Sonuc;
                foreach (DataRow item in dt.Rows)
                {
                    //[Id] ,[FullName] ,[Adress] ,[TaxNumber]
                    uss.Company.ID = item[0]._ToIntegerR();
                    uss.Company.FullName = item[1]._ToString();
                    uss.Company.Adress = item[2]._ToString();
                    uss.Company.TaxNumber = myCrypto.Instance.SifreyiCoz(item[3]._ToString(), globalParameters.YardimciVeri);
                }
            }


            return returnValue;
        }

    }
}
