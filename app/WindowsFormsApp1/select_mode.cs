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
            new Form1(this.DB).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new add_product(this.DB).Show();
        }
    }
}
