using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSqlDatabase
{
    public class SQL2019Backup
    {
        public static string BackupSQL2019(string address, string databaseName)
        {
            SqlConnection connection = new SqlConnection(@"Data Source =.\SQLEXPRESS2019; Initial Catalog = '" + databaseName + "'; Integrated Security = true");
            try
            {
                string query = @"BACKUP DATABASE SamanInsurance TO DISK = '" + (address) + "' " +
                               "WITH FORMAT, MEDIANAME = 'SQLServerBackups',NAME = 'Full Backup of SQLTestDB'; ";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return "OK";
            }
            catch (SqlException sqlx)
            {
                connection.Close();
                return sqlx.Message;

            }

        }
    }
}
