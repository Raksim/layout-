using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class edit_agent : Form
    {
        public Database database;
        public Form select_mode;
        public Agent agent;
        public edit_agent(Database database, Form select_mode,Agent agent)
        {
            InitializeComponent();
            this.database = database;
            this.select_mode = select_mode;
            this.agent = agent;

            comboBox1.DataSource = this.database.get_agenttype();
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "ID";

            textBox1.Text = agent.title;
            comboBox1.SelectedText = agent.type_agent;
            textBox2.Text = agent.Address;
            textBox3.Text = agent.INN;
            textBox4.Text = agent.KPP;
            textBox5.Text = agent.DirectorName;
            textBox6.Text = agent.Phone;
            textBox7.Text = agent.Email;
            numericUpDown1.Value = agent.Priority;
            label10.Text = agent.Logo;
            pictureBox1.Image = Image.FromFile(agent.Logo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Func<bool> n = () =>
            {
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Введите название агента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (textBox3.TextLength == 0)
                {
                    MessageBox.Show("Введите ИНН", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (textBox6.TextLength == 0)
                {
                    MessageBox.Show("Введите номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (MessageBox.Show("Изменить агента?", "Выбор", MessageBoxButtons.YesNo) == DialogResult.Yes ? false : true)
                {
                    return false;
                }
                string img = label10.Text;
                if (openFileDialog1.FileName != "openFileDialog1")
                {
                    img = $"./agents/agent_{Directory.GetFiles("./agents").Length}.jpeg";
                    File.Copy(openFileDialog1.FileName, img);
                }
                this.database.edit_agent(agent.id,textBox1.Text,(int)comboBox1.SelectedValue,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text,img,(int)numericUpDown1.Value);
                this.Dispose();
                select_mode.Show();
                return true;
            };
            n();
        }

        private void edit_agent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.select_mode.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                label10.Text = openFileDialog1.SafeFileName;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
