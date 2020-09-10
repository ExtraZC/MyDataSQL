using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_v01
{
    public partial class Form1 : Form
    {
        string combo1;
        int i, j,k;
        string connection = "Data Source = 192.168.1.104;Initial Catalog = SMS;Persist Security Info = True;User ID = sa;Password = hunter@123456789";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            combo1 = comboBox1.Text;
            SqlConnection conn = new SqlConnection("Data Source = 192.168.1.104;Initial Catalog = SMS;Persist Security Info = True;User ID = sa;Password = hunter@123456789");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM TestZ";
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (combo1 == dt.Rows[i][0].ToString())
                {
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        label1.Text += dt.Rows[i][j].ToString().Trim() + " ";
                    }
                }
            }
            //循环给textBox赋值
            for (k = 1; k < 5; k++)
            {
                TextBox tb = this.Controls["textBox" + k.ToString()] as TextBox; 
                if(tb != null)
                {
                    tb.Text = null;
                }
            }
            label1.Text += "\n";

            conn.Close();
            cmd.Dispose();
        }
        private void button2_Click(object sender,EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Select();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "name";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            combo1 = comboBox1.Text;
            string sql = "UPDATE TestZ SET name='" + textBox1.Text + "',born='" + textBox2.Text + "',age='" + textBox3.Text + "',phone='" + textBox4.Text + "' WHERE name='" + combo1 + "'";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            if (count > 0)
            {
                label1.Text += "修改成功" + "\n";
            }
            else
            {
                label1.Text += "修改失败" + "\n";
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection("Data Source = 192.168.1.104;Initial Catalog = SMS;Persist Security Info = True;User ID = sa;Password = hunter@123456789");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT name FROM TestZ";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            cmd.Dispose();
            return dt;
        }
    }
}
