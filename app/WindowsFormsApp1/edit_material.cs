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
    public partial class edit_material : Form
    {
        public Database database;
        public Form select_mode;
        public int Productid;
        private List<int> add = new List<int> { };
        private List<int> delete = new List<int> { };
        public edit_material(Database database,Form select_mode,int productid)
        {
            InitializeComponent();
            this.database = database;
            this.select_mode = select_mode;
            this.Productid = productid;
            dataGridView1.DataSource = database.get_material();
            dataGridView2.DataSource = database.get_material_product(productid);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Func<bool> line = () =>
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите материал который хотите удалить");
                    return false;
                }
                int d = dataGridView2.SelectedRows[0].Index;
                add.Remove((int)dataGridView2[0, d].Value);
                delete.Add((int)dataGridView2[0, d].Value);
                ((DataTable)dataGridView2.DataSource).Rows.RemoveAt(d);
                return true;
            };
            line();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Func<bool> line = () =>
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите материал");
                    return false;
                }
                int d = dataGridView1.SelectedRows[0].Index;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if ((int)dataGridView2[0, i].Value == (int)dataGridView1[0, d].Value)
                    {
                        return false;
                    }
                }
                add.Add((int)dataGridView1[0, d].Value);
                ((DataTable)dataGridView2.DataSource).Rows.Add((int)dataGridView1[0, d].Value, (string)dataGridView1[1, d].Value, 1);
                return true;
            };
            line();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func<bool> line = () =>
            {
                if (MessageBox.Show("Изменить список материалов", "Выбор", MessageBoxButtons.YesNo) == DialogResult.Yes ? false : true)
                {
                    return false;
                }
                if (add.Count > 0)
                {
                    this.add.ForEach(item => this.database.add_material_product(Productid, item));
                }
                if (delete.Count > 0)
                {
                    this.delete.ForEach(item => this.database.remove_material_product(Productid, item));
                }
                this.Dispose();
                this.select_mode.Show();
                return true;
            };
            line();
        }

        private void edit_material_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.select_mode.Show();
        }
    }
}
