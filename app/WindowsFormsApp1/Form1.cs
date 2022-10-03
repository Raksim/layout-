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
    public partial class Form1 : Form
    {
        public Database DB;
        public Form select_mode;
        public Form1(Database database, Form select_mode)
        {
            InitializeComponent();
            this.DB = database;
            this.select_mode = select_mode;
            this.DB.get_listproduct().ForEach(item => this.create_container_product(item.title,item.type_product, item.articul,item.material, item.image, item.price));
        }

        public void create_container_product(string title, string type, int articu, string material,string image, decimal pric)
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
            material_list.Size = new Size(300,40);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            this.DB.get_listproduct(textBox1.Text).ForEach(item => this.create_container_product(item.title, item.type_product, item.articul, item.material, item.image, item.price));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            select_mode.Show();
        }
    }
}
