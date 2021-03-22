
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.SysWorks;

namespace Common
{
    public class SQL_DB_Functions
    {
        public string Server = "";
        public string Database = "";
        public string UserName = "";
        public string Password = "";

        private string ConnectionString;
        SqlConnection Conn;
        SqlTransaction Trans;


        public sysReturn SetConn()
        {
            sysReturn Retval = new sysReturn();
            try
            {
                ConnectionString = "Data Source=" + Server +
                                  ";Initial Catalog=" + Database +
                                  ";User Id=" + UserName +
                                  ";Password=" + Password + ";";

                Retval.Durum = DurumTip.Ok;
            }
            catch (Exception ex)
            {
                Retval.Durum = DurumTip.Err;
                Retval.HataListe.Add(ex);
            }
            return Retval;


        }

        public sysReturn TestConn()
        {
            sysReturn Retval = new sysReturn();
            try
            {
                OpenConnection();
                Retval.Durum = DurumTip.Ok;
            }
            catch (Exception ex)
            {
                Retval.Durum = DurumTip.Err;
                Retval.HataListe.Add(ex);
            }
            return Retval;


        }

        private void OpenConnection()
        {
            sysReturn oreturn = new sysReturn();
            try
            {
                Conn = new SqlConnection();
                Conn.ConnectionString = ConnectionString;
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private sysReturn CloseConnection()
        {
            sysReturn oreturn = new sysReturn();
            try
            {
                if (Conn == null)
                {
                    oreturn.Durum = DurumTip.Null;
                    return oreturn;
                }
                if (Conn.State != System.Data.ConnectionState.Closed)
                    Conn.Close();
                oreturn.Durum = DurumTip.Ok;
            }
            catch (Exception ex)
            {
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Dispose();
                    Conn = null;
                }
            }
            return oreturn;
        }

        public sysReturn BeginTrans()
        {
            sysReturn oreturn = new sysReturn();
            if (Conn == null)
                Conn = new SqlConnection();
            if (Conn.State != System.Data.ConnectionState.Open)
            {
                Conn.ConnectionString = ConnectionString;
                OpenConnection();

            }
            try
            {
                Trans = Conn.BeginTransaction();
                oreturn.Durum = DurumTip.Ok;
            }
            catch (Exception ex)
            {
                Conn = null;
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            return oreturn;
        }

        public sysReturn CommitTrans()
        {
            sysReturn oreturn = new sysReturn();
            try
            {
                if (Trans == null)
                    throw new Exception("The COMMIT TRANSACTION request has no corresponding BEGIN TRANSACTION");
                Trans.Commit();
                oreturn.Durum = DurumTip.Ok;
            }
            catch (Exception ex)
            {
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            finally
            {
                Trans = null;
                CloseConnection();
            }
            return oreturn;
        }

        public sysReturn RollbackTrans()
        {
            sysReturn oreturn = new sysReturn();
            try
            {
                if (Trans == null)
                    throw new Exception("The ROLLBACK TRANSACTION request has no corresponding BEGIN TRANSACTION");
                Trans.Rollback();
                oreturn.Durum = DurumTip.Ok;
            }
            catch (Exception ex)
            {
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            finally
            {
                Trans = null;
                CloseConnection();
            }
            return oreturn;
        }

        /// <summary>
        /// Datatable Döndürür
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="using_trans"></param>
        /// <returns></returns>
        public sysReturn ExecuteReader(SqlCommand cmd, bool usingTrans)
        {
            SqlDataAdapter da;
            DataTable dt;
            sysReturn oreturn = new sysReturn();
            try
            {
                if (Conn == null)
                    OpenConnection();
                if (usingTrans)
                {
                    if (Trans == null)
                        throw new Exception("request has no corresponding TRANSACTION");
                    cmd.Transaction = Trans;
                }
                cmd.Connection = Conn;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                oreturn.Sonuc = dt;
                if (dt.Rows.Count <= 0)
                    oreturn.Durum = DurumTip.NoData;
                else
                    oreturn.Durum = DurumTip.Ok;

            }
            catch (SqlException sql_ex)
            {
                if (sql_ex.Number == -2146232060)
                    oreturn.Durum = DurumTip.ConflictKey;
                else
                    oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(sql_ex.Message);
            }
            catch (Exception ex)
            {
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            finally
            {
                if (Trans == null)
                    CloseConnection();
                oreturn.SqlString = cmd.CommandText;
            }
            return oreturn;
        }

        /// <summary>
        /// Değişikliğe Uğrayan Kayıt Sayısını Döndürür.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="using_trans"></param>
        /// <returns></returns>
        public sysReturn ExecuteNonQuery(SqlCommand cmd, bool usingTrans)
        {
            sysReturn oreturn = new sysReturn();
            try
            {
                if (Conn == null)
                    OpenConnection();
                if (usingTrans)
                {
                    if (Trans == null)
                        throw new Exception("request has no corresponding TRANSACTION");
                    cmd.Transaction = Trans;
                }
                cmd.Connection = Conn;
                oreturn.Sonuc = cmd.ExecuteNonQuery();
                oreturn.Durum = DurumTip.Ok;
            }
            catch (SqlException sql_ex)
            {
                if (sql_ex.Number == -2146232060)
                    oreturn.Durum = DurumTip.ConflictKey;
                else
                    oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(sql_ex.Message);
            }
            catch (Exception ex)
            {
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            finally
            {
                if (Trans == null)
                    CloseConnection();
                oreturn.SqlString = cmd.CommandText;
            }
            return oreturn;
        }

        /// <summary>
        /// Insert ile Oluşan Identitity'i Döndürür.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="using_trans"></param>
        /// <returns></returns>
        public sysReturn ExecuteIdentity(SqlCommand cmd, bool usingTrans)
        {
            string cmdtext = "";
            sysReturn oreturn = new sysReturn();
            SqlDataAdapter da;
            DataTable dt;
            try
            {
                cmdtext = cmd.CommandText;
                cmd.CommandText += " Select SCOPE_IDENTITY()";

                if (Conn == null)
                    OpenConnection();
                if (usingTrans)
                {
                    if (Trans == null)
                        throw new Exception("request has no corresponding TRANSACTION");
                    cmd.Transaction = Trans;
                }
                cmd.Connection = Conn;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                oreturn.Sonuc = dt.Rows[0][0]._ToInteger();


                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "Select SCOPE_IDENTITY()";
                //oreturn.Sonuc = cmd.ExecuteScalar();
                oreturn.Durum = DurumTip.Ok;

            }
            catch (SqlException sql_ex)
            {
                if (sql_ex.Number == -2146232060)
                    oreturn.Durum = DurumTip.ConflictKey;
                else
                    oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(sql_ex.Message);
            }
            catch (Exception ex)
            {
                oreturn.Durum = DurumTip.Err;
                oreturn.HataListe.Add(ex.Message);
            }
            finally
            {
                if (Trans == null)
                    CloseConnection();
                oreturn.SqlString = cmdtext;
            }
            return oreturn;
        }

        public sysReturn GetDataTable(bool bUseTrans, SqlCommand cmd)
        {
            DataTable Dt = new DataTable();
            sysReturn oRetval = new sysReturn();
            try
            {
                cmd.CommandTimeout = 6000;
                oRetval = ExecuteReader(cmd, bUseTrans);
                if (oRetval.Durum == DurumTip.Err)
                    throw new Exception(oRetval.GetErrors());

                Dt = (DataTable)oRetval.Sonuc;
                oRetval.Sonuc = Dt;
            }
            catch (Exception ex)
            {
                oRetval.Durum = DurumTip.Err;
                oRetval.HataListe.Add(ex.Message);
            }

            return oRetval;
        }

        public sysReturn GetDataTable(bool bUseTrans, SqlCommand cmd, int timeOut)
        {
            DataTable Dt = new DataTable();
            sysReturn oRetval = new sysReturn();
            try
            {
                cmd.CommandTimeout = timeOut;
                oRetval = ExecuteReader(cmd, bUseTrans);
                if (oRetval.Durum == DurumTip.Err)
                    throw new Exception(oRetval.GetErrors());

                Dt = (DataTable)oRetval.Sonuc;
                oRetval.Sonuc = Dt;
            }
            catch (Exception ex)
            {
                oRetval.Durum = DurumTip.Err;
                oRetval.HataListe.Add(ex.Message);
            }

            return oRetval;
        }

        public sysReturn GetDataSet(bool bUseTrans, SqlCommand cmd)
        {
            DataSet Ds = new DataSet();
            sysReturn oRetval = new sysReturn();
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionString))
                {
                    Conn.Open();
                    cmd.Connection = Conn;
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(Ds);
                    oRetval.Sonuc = Ds;
                }
            }
            catch (Exception ex)
            {

                //throw;
            }

            return oRetval;
        }

        public sysReturn GetDataTable(bool bUseTrans, string commandText)
        {
            DataTable Dt = new DataTable();
            sysReturn oRetval = new sysReturn();
            SqlCommand Cmd = new SqlCommand();
            try
            {
                Cmd.CommandText = commandText;
                Cmd.CommandTimeout = 6000;
                oRetval = ExecuteReader(Cmd, bUseTrans);
                if (oRetval.Durum == DurumTip.Err)
                    throw new Exception(oRetval.GetErrors());

                Dt = (DataTable)oRetval.Sonuc;

            }
            catch (Exception ex)
            {
                oRetval.Durum = DurumTip.Err;
                oRetval.HataListe.Add(ex.Message);
                //throw ex;
            }

            return oRetval;
        }

        public sysReturn GetDataSet(bool bUseTrans, string commandText)
        {
            DataSet Ds = new DataSet();
            sysReturn oRetval = new sysReturn();
            SqlCommand Cmd = new SqlCommand();
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionString))
                {
                    Conn.Open();
                    Cmd.CommandText = commandText;
                    Cmd.Connection = Conn;
                    SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                    Adapter.Fill(Ds);
                    oRetval.Sonuc = Ds;

                }
            }
            catch (Exception ex)
            {
                oRetval.Durum = DurumTip.Err;
                oRetval.HataListe.Add(ex.Message);
                //throw;
            }

            return oRetval;
        }
    }
}
