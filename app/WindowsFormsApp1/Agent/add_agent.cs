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
    public partial class add_agent : Form
    {
        private Database database;
        private Form select_mode;
        public add_agent(Database database,Form select_mode)
        {
            InitializeComponent();
            this.database = database;
            this.select_mode = select_mode;
            comboBox1.DataSource = this.database.get_agenttype();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Title";
        }

        private void add_agent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.select_mode.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Func<bool> f = () =>
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
                string img = "";
                if (openFileDialog1.FileName != "openFileDialog1")
                {
                    img = $"./agents/agent_{Directory.GetFiles("./agents").Length}.jpeg";
                    File.Copy(openFileDialog1.FileName, img);
                }
                this.database.add_agent(textBox1.Text,
                    (int)comboBox1.SelectedValue,
                    textBox2.Text, textBox3.Text,
                    textBox4.Text, textBox5.Text,
                    textBox6.Text, textBox7.Text,
                    img != "" ? img : null,
                    (int)numericUpDown1.Value);
                MessageBox.Show("Агент добавлен");
                this.Dispose();
                this.select_mode.Show();
                return true;
            };
            f();
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
