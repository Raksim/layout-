using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class select_product : Form
    {
        public Database DB;
        public Form select_mode;
        public List<Product> listproduct;
        private string mode;
        private string search = "";
        private string ORDER_BY = "ID ASC";
        private string filter = "";

        public select_product(Database database, Form select_mode,string mode)
        {
            InitializeComponent();
            this.DB = database;
            this.select_mode = select_mode;
            this.mode = mode;
            this.refresh();
        }
        public void create_container_product(int id,string title, string type, int articu, string material, string image, decimal pric)
        {
            Panel container = new Panel();
            PictureBox product_img = new PictureBox();
            FlowLayoutPanel group_typeandtitle = new FlowLayoutPanel();
            Label type_product = new Label();
            Label line = new Label();
            Label title_product = new Label();
            Label articul = new Label();
            Label material_list = new Label();
            Label price = new Label();

            title_product.Text = title;
            title_product.AutoSize = true;
            type_product.AutoSize = true;
            type_product.Text = type;
            articul.AutoSize = true;
            articul.Text = articu.ToString();
            container.Name = id.ToString();
            container.Click += showid;
            container.BorderStyle = BorderStyle.FixedSingle;
            container.Size = new Size(485, 81);
            line.Text = "|";
            line.AutoSize = true;
            product_img.Size = new Size(106, 73);
            product_img.Location = new Point(3, 3);
            product_img.SizeMode = PictureBoxSizeMode.Zoom;
            product_img.Image = Image.FromFile($".{image}");
            group_typeandtitle.Size = new Size(250, 20);
            group_typeandtitle.Location = new Point(115, 3);
            articul.Location = new Point(118, 26);
            material_list.Text = $"Материалы:{material}";
            material_list.Location = new Point(115, 47);
            material_list.Size = new Size(300, 40);
            price.Location = new Point(424, 10);
            price.Text = pric.ToString();

            container.Controls.Add(product_img);

            group_typeandtitle.Controls.Add(type_product);
            group_typeandtitle.Controls.Add(line);
            group_typeandtitle.Controls.Add(title_product);

            container.Controls.Add(group_typeandtitle);
            container.Controls.Add(articul);
            container.Controls.Add(material_list);
            container.Controls.Add(price);

            flowLayoutPanel1.Controls.Add(container);
        }
        
        private void showid(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "remove":
                    Func<bool> d = () =>
                    {
                        if (MessageBox.Show("Удалить эту продукцию", "Выбор", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes ? false : true)
                        {
                            return false;
                        }
                        this.DB.remove_product(Convert.ToInt32(((Panel)sender).Name));
                        flowLayoutPanel1.Controls.Clear();
                        this.refresh();
                        return true;
                    };
                    d();
                    break;
                case "edit_product":
                    foreach (Product n in this.listproduct)
                    {
                        if (n.id == Convert.ToInt32(((Panel)sender).Name))
                        {
                            new edit_product(this.DB,n,this.select_mode).Show();
                            this.Dispose();
                        }
                    }
                    break;
                case "edit_material_product":
                    new edit_material(this.DB,this.select_mode,Convert.ToInt32(((Panel)sender).Name)).Show();
                    this.Dispose();
                    break;
                default:
                    break;
            }
        }
        private void refresh()
        {
            flowLayoutPanel1.Controls.Clear();
            if (filter.Length != 0)
            {
                listproduct = this.DB.get_listproduct(search, ORDER_BY, filter);
                listproduct.ForEach(item => this.create_container_product(item.id,item.title, item.type_product, item.articul, item.material, item.image, item.price));
            }
            else
            {
                listproduct = this.DB.get_listproduct(search, ORDER_BY);
                listproduct.ForEach(item => this.create_container_product(item.id,item.title, item.type_product, item.articul, item.material, item.image, item.price));
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    this.ORDER_BY = "Product.Title ";
                    break;
                case 1:
                    this.ORDER_BY = "Product.ProductTypeID ";
                    break;
                case 2:
                    this.ORDER_BY = "Product.ArticleNumber ";
                    break;
                case 3:
                    this.ORDER_BY = "Product.MinCostForAgent ";
                    break;
            }
            contextMenuStrip1.Show(MousePosition);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            contextMenuStrip2.Items.Clear();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    this.filter = "ProductTypeID = ";
                    break;
            }
            foreach (DataRow n in this.DB.get_producttype().Rows)
            {
                contextMenuStrip2.Items.Add(Convert.ToString(n[1]), null, this.selectmenu);
            }
            contextMenuStrip2.Show(MousePosition);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            select_mode.Show();
        }

        private void возрастаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ORDER_BY += "ASC";
            this.refresh();
        }

        private void убываниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ORDER_BY += "DESC";
            this.refresh();
        }
        private void selectmenu(object sender, EventArgs e)
        {
            this.filter += contextMenuStrip2.Items.IndexOf(((ToolStripItem)sender)) + 1;
            this.refresh();
        }

        private void select_product_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.select_mode.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                e.Handled = true;
                this.search = textBox1.Text;
                this.refresh();
            }
        }
    }
}
