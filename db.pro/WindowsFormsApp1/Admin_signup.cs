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
    public partial class Admin_signup : Form
    {
        public Admin_signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Adminstrator values('" + textBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox5.Text.ToString() + "')", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("succssful");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a = new login();
            a.Show();
            this.Hide();
        }
    }
}
