using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Common
{
    public sealed class MyConnect
    {
        private static readonly Lazy<MyConnect> lazy = new Lazy<MyConnect>(() => new MyConnect());

        public static MyConnect Instance { get { return lazy.Value; } }

        private MyConnect()
        {
            //clsLisans.Instance.ToString();
        }

        #region Class
        public sealed class KomutArgumanlari
        {
            // Properties
            public object Parametre { get; set; }
            public string ParametreAdi { get; set; }

        }

        public sealed class TransacsionArgumanlari
        {
            public CommandType KomtTipi { get; set; }
            public string Komut { get; set; }
            public KomutArgumanlari[] KomutArgumanDizisi { get; set; }
        }
        #endregion

        public Exception exp = new Exception();

        public SqlConnection ConnectionString(string str)
        {
            return new SqlConnection(str);
        }

        public SqlConnectionStringBuilder ConnectionStringB(string str)
        {
            return new SqlConnectionStringBuilder(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server">Server Adı</param>
        /// <param name="user">Kullanıcı</param>
        /// <param name="pass">Şifresi</param>
        /// <param name="db">DataBase</param>
        /// <param name="connecitonTimeout">Default 15sn. Veri tabanına ne kadar süre bağlanamazsa hata verecektir.</param>
        /// <param name="sql_windows">Sql(true) mi, Windows(false) Mu</param>
        /// <returns></returns>
        public SqlConnection ConnectionString(string server, int port, string user, string pass, string db, int connecitonTimeout, bool sql_windows)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = port == 0 ? server : $"{server},{port}";
            if (sql_windows)
            {
                builder.Password = pass;
                builder.UserID = user;
                builder.IntegratedSecurity = false;
            }
            else
                builder.IntegratedSecurity = true;
            builder.PersistSecurityInfo = false;
            builder.InitialCatalog = db;
            builder.ConnectTimeout = connecitonTimeout;
            return new SqlConnection(builder.ConnectionString);
        }
        /// <summary>
        /// Bağlantı başarılı ise true döner
        /// </summary>
        /// <param name="ConnectionStrings"></param>
        /// <param name="hataMesaji"></param>
        /// <returns>bool</returns>
        public bool ConnectionControl(string ConnectionStrings, out Exception exp)
        {
            exp = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStrings))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                }

                return true;
            }
            catch (Exception exception)
            {
                exp = exception;
                return false;
            }
        }

        SqlConnection Conn;

        public bool ExecuteNonQuery(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, out Exception _hataMesaji, params KomutArgumanlari[] arguman)
        {
            _hataMesaji = null;
            bool flag = false;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                using (SqlCommand command = new SqlCommand(komut, connection))
                {
                    command.CommandType = komutTipi;
                    command.CommandTimeout = timeOut;
                    if (arguman.ToList<KomutArgumanlari>().Count > 0)
                        foreach (KomutArgumanlari i_ in arguman.ToList<KomutArgumanlari>())
                            command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                    try
                    {
                        if (connection.State == ConnectionState.Closed) connection.Open();
                        flag = command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        _hataMesaji = ex;
                    }
                }
            }
            
            return flag;
        }

        public bool ExecuteNonQuery_WithTransaction(string ConnectionStrings, out Exception _hataMesaji, TransacsionArgumanlari[] transactionArgs)
        {
            _hataMesaji = null;
            bool flag = true;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                SqlTransaction transaction = null;
                try
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    transaction = connection.BeginTransaction();
                    foreach (TransacsionArgumanlari i_ in transactionArgs)
                    {
                        using (SqlCommand command = new SqlCommand(i_.Komut, connection, transaction))
                        {
                            foreach (KomutArgumanlari i_2 in i_.KomutArgumanDizisi)
                                command.Parameters.AddWithValue(i_2.ParametreAdi, i_2.Parametre);
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    flag = false;
                    transaction.Rollback();
                    _hataMesaji = ex;
                }
            }
            return flag;
            
          
        }

        public DataTable ExecuteReader(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, out Exception _hataMesaji, params KomutArgumanlari[] arguman)
        {
            _hataMesaji = null;
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                using (SqlCommand command = new SqlCommand(komut, connection))
                {
                    command.CommandType = komutTipi;
                    command.CommandTimeout = timeOut;
                    if (arguman.ToList<KomutArgumanlari>().Count > 0)
                        foreach (KomutArgumanlari i_ in arguman.ToList<KomutArgumanlari>())
                            command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                    try
                    {
                        if (connection.State != ConnectionState.Open) connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        reader = null;
                    }
                    catch (Exception ex)
                    {
                        _hataMesaji = ex;
                    }
                }
            }
            return table;
          
        }

        public object ExecuteScalar(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, out Exception _hataMesaji, params KomutArgumanlari[] arguman)
        {
            _hataMesaji = null;
            object obj2 = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                using (SqlCommand command = new SqlCommand(komut, connection))
                {
                    command.CommandType = komutTipi;
                    command.CommandTimeout = timeOut;
                    if (arguman.ToList<KomutArgumanlari>().Count > 0)
                        foreach (KomutArgumanlari i_ in arguman.ToList<KomutArgumanlari>())
                            command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                    try
                    {
                        if (connection.State != ConnectionState.Open) connection.Open();
                        obj2 = command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        obj2 = 0;
                        _hataMesaji = ex;
                    }
                }
            }
            return obj2;
         
        }

        public int ExecuteScalar_Int(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, out Exception _hataMesaji, params KomutArgumanlari[] arguman)
        {
            _hataMesaji = null;
            int obj2 = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                using (SqlCommand command = new SqlCommand(komut, connection))
                {
                    command.CommandType = komutTipi;
                    command.CommandTimeout = timeOut;
                    if (arguman.ToList<KomutArgumanlari>().Count > 0)
                        foreach (KomutArgumanlari i_ in arguman.ToList<KomutArgumanlari>())
                            command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                    try
                    {
                        if (connection.State != ConnectionState.Open) connection.Open();
                        obj2 = command.ExecuteScalar()._ToIntegerR();
                    }
                    catch (Exception ex)
                    {
                        obj2 = 0;
                        _hataMesaji = ex;
                    }
                }
            }
            return obj2;
         
        }

        public decimal ExecuteScalar_Decimal(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, out Exception _hataMesaji, params KomutArgumanlari[] arguman)
        {
            _hataMesaji = null;
            decimal obj2 = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                using (SqlCommand command = new SqlCommand(komut, connection))
                {
                    command.CommandType = komutTipi;
                    command.CommandTimeout = timeOut;
                    if (arguman.ToList<KomutArgumanlari>().Count > 0)
                        foreach (KomutArgumanlari i_ in arguman.ToList<KomutArgumanlari>())
                            command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                    try
                    {
                        if (connection.State != ConnectionState.Open) connection.Open();
                        obj2 = command.ExecuteScalar()._ToDecimalR();
                    }
                    catch (Exception ex)
                    {
                        obj2 = 0;
                        _hataMesaji = ex;
                    }
                }
            }
            return obj2;
         
        }

        public double ExecuteScalar_Double(string ConnectionStrings, string komut, CommandType komutTipi, int timeOut, out Exception _hataMesaji, params KomutArgumanlari[] arguman)
        {
            _hataMesaji = null;
            double obj2 = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                using (SqlCommand command = new SqlCommand(komut, connection))
                {
                    command.CommandType = komutTipi;
                    command.CommandTimeout = timeOut;
                    if (arguman.ToList<KomutArgumanlari>().Count > 0)
                        foreach (KomutArgumanlari i_ in arguman.ToList<KomutArgumanlari>())
                            command.Parameters.AddWithValue(i_.ParametreAdi, i_.Parametre);
                    try
                    {
                        if (connection.State != ConnectionState.Open) connection.Open();
                        obj2 = command.ExecuteScalar()._ToDoubleR();
                    }
                    catch (Exception ex)
                    {
                        obj2 = 0;
                        _hataMesaji = ex;
                    }
                }
            }
            return obj2;
         
        }

        public bool TabloKolonVarmi(string ConnectionStrings, string tabloAdi, string kolonAdi, out Exception _hataMesaji)
        {
            return ExecuteScalar_Int(ConnectionStrings, string.Format("select COUNT(*) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", tabloAdi, kolonAdi), CommandType.Text, 30, out _hataMesaji) > 0;
        }

        public void TabloyaKolonEkle(string ConnectionStrings, string tabloAdi, string kolonAdi, string dataType, out Exception _hataMesaji)
        {
            ExecuteNonQuery(ConnectionStrings, string.Format("ALTER TABLE {0} ADD {1} {2}; ", tabloAdi, kolonAdi, dataType), CommandType.Text, 30, out _hataMesaji);
        }

        public bool TabloVarMi(string ConnectionStrings, string tabloAdi, out Exception _hataMesaji)
        {
            return ExecuteScalar_Int(ConnectionStrings, string.Format("SELECT COUNT(*) FROM SYS.tables WHERE NAME = '{0}'", tabloAdi), CommandType.Text, 30,
                out _hataMesaji) > 0;
        }

        public DateTime? SonBackupAlmaZamani(string ConnectionStrings, out Exception _hataMesaji)
        {
            return ExecuteScalar(ConnectionStrings, "SELECT MAX(backup_finish_date) FROM msdb.dbo.backupset where database_name = @Name", CommandType.Text, 30,
                out _hataMesaji, new KomutArgumanlari() { Parametre = ConnectionString(ConnectionStrings).Database, ParametreAdi = "@Name" })._ToDateTime();
        }

        public void VeritabanindakiTumTablolariSilme(string sqlConnection, out Exception _hataMesaji)
        {
            //Tablolar arasındaki ilişkilerin tamamımı silindi
            MyConnect.Instance.ExecuteNonQuery(sqlConnection, "DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR SET @Cursor = CURSOR FAST_FORWARD FOR SELECT DISTINCT sql = 'ALTER TABLE [' + TableCons.TABLE_NAME + '] DROP [' + ReferentialCons.CONSTRAINT_NAME + ']' FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS ReferentialCons LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TableCons ON TableCons.CONSTRAINT_NAME = ReferentialCons.CONSTRAINT_NAME OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql WHILE (@@FETCH_STATUS = 0) BEGIN Exec SP_EXECUTESQL @Sql FETCH NEXT FROM @Cursor INTO @Sql END CLOSE @Cursor DEALLOCATE @Cursor GO", CommandType.Text, 60, out _hataMesaji);
            //Tüm Tablolar Silindi
            MyConnect.Instance.ExecuteNonQuery(sqlConnection, "EXEC sp_MSForEachTable 'DROP TABLE ?'", CommandType.Text, 60, out _hataMesaji);
        }

        public void VeritabanindakiTumViewleriSilme(string sqlConnection, out Exception _hataMesaji)
        {
            //Tüm Viewler Silindi
            MyConnect.Instance.ExecuteNonQuery(sqlConnection, "DECLARE @query VARCHAR(MAX) = ''; SELECT @query = @query + 'DROP VIEW [' + name + '];' FROM sys.views; EXEC(@query);", CommandType.Text, 60, out _hataMesaji);
        }

        public void VeritabanindakiTumFonksiyonlariSilme(string sqlConnection, out Exception _hataMesaji)
        {
            //Tüm Fonksiyonlar Silindi
            MyConnect.Instance.ExecuteNonQuery(sqlConnection, "DECLARE @functionName VARCHAR(500) DECLARE cur CURSOR FOR SELECT [name] FROM sys.objects WHERE TYPE = 'fn' OPEN cur FETCH NEXT FROM cur INTO @functionName WHILE @@fetch_status = 0 BEGIN EXEC('DROP FUNCTION ' + @functionName) FETCH NEXT FROM cur INTO @functionName END CLOSE cur DEALLOCATE cur", CommandType.Text, 60, out _hataMesaji);
        }

        public void SatirTabloIDleriniVirgulleAyiranFunction(string sqlConnection, string FunctionName, string TableName, string SatirAnaID, out Exception _hataMesaji)
        {
            MyConnect.Instance.ExecuteNonQuery(sqlConnection, $"CREATE FUNCTION {FunctionName} (@AnaID int) RETURNS VARCHAR(MAX) AS BEGIN DECLARE @Idler varchar(50) SELECT @Idler = COALESCE(@Idler + ',', '') + ISNULL(CONVERT(NVARCHAR(50), ID),'') FROM {TableName} WHERE {SatirAnaID} = @AnaID RETURN @Idler END", CommandType.Text, 60, out _hataMesaji);
        }

        public DataTable TabloBaglantilari(string sqlConnection, string tableName)
        {
            return ExecuteReader(sqlConnection, $"SELECT * FROM SYS.foreign_keys where referenced_object_id = object_id('{tableName}')", CommandType.Text, 60, out MyConnect.Instance.exp);
        }

        public DataTable SqlKilitliTablolarinListesi(string sqlConnection)
        {
            return ExecuteReader(sqlConnection, $"SELECT DISTINCT OBJECT_NAME(A.rsc_objid), A.req_spid, B.loginame FROM SYS.syslockinfo A (NOLOCK) JOIN SYS.sysprocesses AS B (NOLOCK) ON A.req_spid = B.spid WHERE OBJECT_NAME(A.rsc_objid) IS NOT NULL", CommandType.Text, 60, out MyConnect.Instance.exp);
        }
    }
}
