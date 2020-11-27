using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DL_Dapper
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EquipoHR"].ConnectionString.ToString();
        }
        public static SqlCommand CreateCommand(string Query, SqlConnection context)
        {
            context.Open();
            SqlCommand cmd = new SqlCommand(Query, context);
            return cmd;
        }

        public static int ExecuteCommand(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }
        public static DataTable ExecuteCommandSelect(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
    }
}
