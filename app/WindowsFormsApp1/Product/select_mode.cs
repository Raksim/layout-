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
    public partial class select_mode : Form
    {
        public Database DB;
        public select_mode()
        {
            InitializeComponent();
            this.DB = new Database();
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
    }
}
