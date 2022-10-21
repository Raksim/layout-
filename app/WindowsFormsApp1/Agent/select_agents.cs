using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class select_agents : Form
    {
        public Database DB;
        public Form select_mode;
        public List<Agent> listagents;
        private string mode;
        private string search = "";
        private string ORDER_BY = "Agent.ID ASC";
        private string filter = "";

        public select_agents(Database database, Form select_mode, string mode)
        {
            InitializeComponent();
            this.DB = database;
            this.select_mode = select_mode;
            this.mode = mode;
            this.refresh();
        }

        public void create_contener_agent(int id, string title, string type, string Phone, string Logo,int Amount_sales)
        {
            Panel contaner = new Panel();
            PictureBox img = new PictureBox();
            FlowLayoutPanel name_and_type = new FlowLayoutPanel();
            Label type_agent = new Label();
            Label separator = new Label();
            Label name = new Label();
            Label phone = new Label();
            Label sales = new Label();

            contaner.BorderStyle = BorderStyle.FixedSingle;
            contaner.Name = id.ToString();
            contaner.Click += showid;
            contaner.Size = new Size(500, 89);
            img.Location = new Point(0, 0);
            img.Size = new Size(119, 86);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            img.Image = Image.FromFile(Logo);
            name_and_type.Location = new Point(123, 3);
            name_and_type.Size = new Size(315, 22);
            type_agent.Text = type;
            type_agent.AutoSize = true;
            separator.Text = "|";
            separator.AutoSize = true;
            name.Text = title;
            name.AutoSize = true;
            phone.Text = Phone;
            phone.Location = new Point(126, 48);
            phone.AutoSize = true;
            sales.Text = $"{Amount_sales}";
            sales.Location = new Point(463, 37);
            sales.AutoSize = true;

            contaner.Controls.Add(img);
            contaner.Controls.Add(name_and_type);
            name_and_type.Controls.Add(type_agent);
            name_and_type.Controls.Add(separator);
            name_and_type.Controls.Add(name);
            contaner.Controls.Add(sales);
            contaner.Controls.Add(phone);
            flowLayoutPanel1.Controls.Add(contaner);
        }

        private void showid(object sender, EventArgs e)
        {
            switch (this.mode)
            {
                case "remove":
                    Func<bool> d = () =>
                    {
                        if (MessageBox.Show("Удалить агента?", "Выбор", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? false : true)
                        {
                            return false;
                        }
                        if (Convert.ToInt32(((Panel)sender).Controls[2].Text) != 0)
                        {
                            MessageBox.Show("У агента есть информация о реализованной продукции, удаление запрещается","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return false;
                        }
                        this.DB.remove_agent(Convert.ToInt32(((Panel)sender).Name));
                        flowLayoutPanel1.Controls.Clear();
                        this.refresh();
                        return true;
                    };
                    d();
                    break;
                case "edit":
                    this.Hide();
                    foreach (Agent n in this.listagents)
                    {
                        if (n.id == Convert.ToInt32(((Panel)sender).Name))
                        {
                            new edit_agent(this.DB, this.select_mode,n).Show();
                            this.Dispose();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void refresh()
        {
            flowLayoutPanel1.Controls.Clear();
            if (filter.Length !=0)
            {
                this.listagents = this.DB.get_listagent(search, ORDER_BY, filter);
                listagents.ForEach(item => this.create_contener_agent(item.id, item.title, item.type_agent, item.Phone, item.Logo, item.Amount_sales));
            }
            else
            {
                this.listagents = this.DB.get_listagent(search, ORDER_BY);
                listagents.ForEach(item => this.create_contener_agent(item.id, item.title, item.type_agent, item.Phone, item.Logo, item.Amount_sales));
            }
        }

        private void select_agents_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.select_mode.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            contextMenuStrip2.Items.Clear();
            contextMenuStrip2.Items.Add("Все типы",null, this.selectmenu);
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    this.filter = "AgentTypeID = ";
                    break;
            }
            foreach (DataRow n in this.DB.get_agenttype().Rows)
            {
                contextMenuStrip2.Items.Add(Convert.ToString(n[1]), null, this.selectmenu);
            }
            contextMenuStrip2.Show(MousePosition);
        }
        private void selectmenu(object sender, EventArgs e)
        {
            if (((ToolStripItem)sender).Text == "Все типы")
            {
                this.filter = "";
            }
            else
            {
                this.filter += contextMenuStrip2.Items.IndexOf(((ToolStripItem)sender));
            }
            this.refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    this.ORDER_BY = "Agent.Title ";
                    break;
                case 1:
                    this.ORDER_BY = "Agent.AgentTypeID ";
                    break;
                case 2:
                    this.ORDER_BY = "Agent.INN ";
                    break;
                case 3:
                    this.ORDER_BY = "Agent.Priority ";
                    break;
            }
            contextMenuStrip1.Show(MousePosition);
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
