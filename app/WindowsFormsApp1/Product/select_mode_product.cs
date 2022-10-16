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
    public partial class select_mode_product : Form
    {
        public Database DB;
        private Form main;
        public select_mode_product(Database database,Form main)
        {
            InitializeComponent();
            this.DB = database;
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_product(this.DB,this,"view").Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new add_product(this.DB, this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_product(this.DB, this,"remove").Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_product(this.DB, this, "edit_product").Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_product(this.DB, this, "edit_material_product").Show();
        }

        private void select_mode_product_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.main.Show();
        }
    }
}
