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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Adminstrator WHERE username='" + textBox1.Text.ToString() + "' AND Acc_Password='" + textBox2.Text + "'", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form a = new admin_options();
                a.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid username or password");

            sqlConnection.Close();          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Customer WHERE username='" + textBox1.Text.ToString() + "' AND Acc_Password='" + textBox2.Text + "'", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form a = new customer_options();
                a.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid username or password");

            sqlConnection.Close();
         








           







        }
    }
}
