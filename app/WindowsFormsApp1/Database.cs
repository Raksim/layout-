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
    public class Database
    {
        public SqlCommand cmd;
        public SqlConnection connection;
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
        private List<Product> create_listproduct(DataTable listproduct)
        {
            List<Product> list_product = new List<Product>();
            foreach (DataRow stream in listproduct.Rows)
            {
                string Material = getTableListMaterial((int)stream[0]);
                list_product.Add(new Product((int)stream[0], (string)stream[1], stream[2].ToString(), Convert.ToInt32(stream[3]), Material, stream[4].ToString() != "" ? stream[4].ToString() : "/picture.png", (decimal)stream[5]));
            }
            return list_product;
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
        
        public DataTable get_material_product(int id)
        {
            SqlDataAdapter data = new SqlDataAdapter($@"select MaterialID,Material.Title as MaterialTitle,Count from ProductMaterial
                                                    INNER join Material on Material.ID = MaterialID
                                                    where ProductID = {id}",this.connection);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet.Tables[0];
        }
        public DataTable get_material()
        {
            SqlDataAdapter data = new SqlDataAdapter($@"select * from Material", this.connection);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet.Tables[0];
        }
        public List<Product> get_listproduct()
        {
            DataTable listproduct = getTableListProduct();
            return create_listproduct(listproduct);
        }
        public List<Product> get_listproduct(string search)
        {
            DataTable listproduct = getTableListProduct(search);
            return create_listproduct(listproduct);
        }
        public DataTable get_listTypeProduct()
        {
            SqlDataAdapter data = new SqlDataAdapter("select * from ProductType", this.connection);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet.Tables[0];
        }
        public void add_product(string title,int typeproduct,int articul,string description,string image,int numberworkshop,decimal MinCostForAgent)
        {
            this.cmd.CommandText = $@"INSERT INTO Product
                                    VALUES ('{title}',{typeproduct},'{articul}','{description}','{image}',0,{numberworkshop},{MinCostForAgent.ToString().Replace(',','.')})";
            this.cmd.ExecuteNonQuery();
        }
        public void remove_product(int id)
        {
            this.cmd.CommandText = $@"DELETE FROM Product WHERE ID = {id}";
            this.cmd.ExecuteNonQuery();
        }
        public void edit_product(int id,string title,int typeproduct,int ArticleNumber,string Image,decimal MinCostForAgent)
        {
            this.cmd.CommandText = $@"UPDATE Product set Title = '{title}',ProductTypeID = {typeproduct},ArticleNumber = '{ArticleNumber}',Image = '{Image}',MinCostForAgent = {MinCostForAgent.ToString().Replace(',','.')}  WHERE ID = {id}";
            this.cmd.ExecuteNonQuery();
        }
        public void add_material_product(int product,int material)
        {
            this.cmd.CommandText = $@"INSERT INTO ProductMaterial VALUES ({product},{material},1)";
            this.cmd.ExecuteNonQuery();
        }
        public void remove_material_product(int product, int material)
        {
            this.cmd.CommandText = $@"DELETE FROM ProductMaterial where ProductID = {product} AND MaterialID = {material}";
            this.cmd.ExecuteNonQuery();
        }
    }
}
