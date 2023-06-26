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
    public partial class customer_signup : Form
    {
        public customer_signup()
        {
            InitializeComponent();
        }
        public string con = @"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True";
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form c = new login();
            c.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer values('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "')", sqlConnection);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand(" select UserID from Customer where username = '"+textBox4.Text.ToString()+"'", sqlConnection);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("insert into Cus_phone values('" +cmd1.ExecuteScalar()  + "','" + textBox7.Text.ToString() + "')", sqlConnection);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("insert into Cus_phone values('" + cmd1.ExecuteScalar() + "','" + textBox8.Text.ToString() + "')", sqlConnection);
            cmd3.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("succssful");
        }
    }
}
