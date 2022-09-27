using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WindowsFormsApp1
{
    class Database
    {
        SqlCommand cmd;
        SqlConnection connection;
        public Database()
        {
            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            this.connection.Open();
            this.cmd = new SqlCommand("",this.connection);
        }

        public List<Product> get_listproduct()
        {
            this.cmd.CommandText = "select * from Product";
            SqlDataReader stream = this.cmd.ExecuteReader();
            List<Product> list_product = new List<Product>();
            while (stream.Read())
            {
                list_product.Add(new Product((string)stream[1],stream[2].ToString(),Convert.ToInt32(stream[3]),"null",(decimal)stream[8]));
            }
            stream.Close();
            return list_product;
        }
    }
}
