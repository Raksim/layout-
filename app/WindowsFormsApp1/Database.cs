using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

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

        private string getTableListMaterial(int IdProduct)
        {
            string Material = "";
            this.cmd.CommandText = $@"select Material.Title as MaterialTitle,Count from ProductMaterial
                                        inner join Product
                                        on Product.ID = ProductMaterial.ProductID
                                        inner join Material
                                        on Material.ID = ProductMaterial.MaterialID
                                        where Product.ID = {IdProduct}";
            SqlDataReader stream2 = this.cmd.ExecuteReader();
            while (stream2.Read())
            {
                Material += $",{(string)stream2[0]}";
            }
            stream2.Close();
            return Material;
        }
        private DataTable getTableListProduct()
        {
            SqlDataAdapter data = new SqlDataAdapter($@"select Product.ID, Product.Title,ProductType.Title,ArticleNumber,Image,MinCostForAgent from Product
                                                    INNER JOIN ProductType
                                                    on ProductType.ID = Product.ProductTypeID", this.connection);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet.Tables[0];
        }
        private DataTable getTableListProduct(string search)
        {
            SqlDataAdapter data = new SqlDataAdapter($@"select Product.ID, Product.Title,ProductType.Title,ArticleNumber,Image,MinCostForAgent from Product
                                                    INNER JOIN ProductType
                                                    on ProductType.ID = Product.ProductTypeID
                                                    where Product.Title LIKE '%{search}%'", this.connection);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet.Tables[0];
        }
        public List<Product> get_listproduct()
        {
            DataTable listproduct = getTableListProduct();
            List<Product> list_product = new List<Product>();
            foreach (DataRow stream in listproduct.Rows)
            {
                string Material = "";
                this.cmd.CommandText = $@"select Material.Title as MaterialTitle,Count from ProductMaterial
                                        inner join Product
                                        on Product.ID = ProductMaterial.ProductID
                                        inner join Material
                                        on Material.ID = ProductMaterial.MaterialID
                                        where Product.ID = {(int)stream[0]}";
                SqlDataReader stream2 = this.cmd.ExecuteReader();
                while (stream2.Read())
                {
                    Material += $",{(string)stream2[0]}";
                }
                stream2.Close();
                list_product.Add(new Product((string)stream[1], stream[2].ToString(), Convert.ToInt32(stream[3]), Material, stream[4].ToString() != "" ? stream[4].ToString() : "/picture.png", (decimal)stream[5]));
            }
            return list_product;
        }
        public List<Product> get_listproduct(string search)
        {
            DataTable listproduct = getTableListProduct(search);
            List<Product> list_product = new List<Product>();
            foreach (DataRow stream in listproduct.Rows)
            {
                string Material = getTableListMaterial((int)stream[0]);
                list_product.Add(new Product((string)stream[1], stream[2].ToString(), Convert.ToInt32(stream[3]), Material, stream[4].ToString() != "" ? stream[4].ToString() : "/picture.png", (decimal)stream[5]));
            }
            return list_product;
        }
    }
}
