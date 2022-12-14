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
    public partial class add_product : Form
    {
        public Database database;
        public Form form;
        public add_product(Database database,Form form)
        {
            InitializeComponent();
            this.database = database;
            this.form = form;
            comboBox1.DataSource = this.database.get_listTypeProduct();
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label6.Text = openFileDialog1.SafeFileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func<bool> f = () =>
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Введите название продукции","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                string img = "";
                if (openFileDialog1.FileName != "openFileDialog1")
                {
                    img = $"./products/paper_{Directory.GetFiles("./products").Length}.jpeg";
                    File.Copy(openFileDialog1.FileName, img);
                }
                this.database.add_product(
                    textBox1.Text,
                    (int)comboBox1.SelectedValue,
                    Convert.ToInt32(numericUpDown3.Value),
                    textBox3.TextLength != 0 ? textBox3.Text : null,
                    img != "" ? img : null,
                    Convert.ToInt32(numericUpDown1.Value),
                    numericUpDown2.Value);
                MessageBox.Show("Продукция добавленна");
                return true;
            };
            f();
        }

        private void add_product_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }
    }
}
