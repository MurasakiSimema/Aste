using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergonziVerifica
{
    public abstract class DAL
    {
        string con = @"Data Source=.;Initial Catalog=Aste;User ID=sa;Password=password.123";
        SqlConnection cnn;
        public DAL()
        {
            cnn = new SqlConnection(con);
            cnn.Open();
        }
        public void Close()
        {
            cnn.Close();
        }
        protected SqlCommand CreaCommand(string sql)
        {
            return new SqlCommand(sql, cnn);
        }
        protected DataTable LeggiDB(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            da.Fill(dt);
            return dt;
        }
    }
}
