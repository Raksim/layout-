using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class edit_product : Form
    {
        public Database database;
        public Product product;
        public Form select_mode;
        public edit_product(Database database,Product product,Form select_mode)
        {
            InitializeComponent();
            this.database = database;
            this.product = product;
            this.select_mode = select_mode;
            comboBox1.DataSource = this.database.get_listTypeProduct();
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "ID";

            textBox1.Text = product.title;
            comboBox1.Text = product.type_product;
            numericUpDown3.Value = product.articul;
            label6.Text = product.image;
            numericUpDown2.Value = product.price;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Изменить эту продукцию", "Выбор", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false)
            {
                if (openFileDialog1.FileName != "openFileDialog1")
                {
                    File.Copy(openFileDialog1.FileName, $"./products/paper_{Directory.GetFiles("./products").Length}.jpeg");
                }
                this.database.edit_product(product.id,textBox1.Text,(int)comboBox1.SelectedValue,Convert.ToInt32(numericUpDown3.Value), $"/products/paper_{Directory.GetFiles("./products").Length - 1}.jpeg", numericUpDown2.Value);
                this.Dispose();
                select_mode.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label6.Text = openFileDialog1.SafeFileName;
        }

        private void edit_product_FormClosed(object sender, FormClosedEventArgs e)
        {
            select_mode.Show();
        }
    }
}
