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
    public partial class products_and_agents : Form
    {
        private Database database;

        public products_and_agents()
        {
            InitializeComponent();
            this.database = new Database();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_mode_agent(this.database, this).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_mode_product(this.database,this).Show();
        }
    }
}
