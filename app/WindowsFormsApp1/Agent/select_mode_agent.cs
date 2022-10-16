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
    public partial class select_mode_agent : Form
    {
        public Database database;
        private Form Main;
        public select_mode_agent(Database database,Form Main)
        {
            this.Main = Main;
            this.database = database;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_agents(this.database,this, "view").Show();
        }

        private void select_mode_agent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new add_agent(this.database,this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_agents(this.database, this, "remove").Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new select_agents(this.database, this, "edit").Show();
        }
    }
}
