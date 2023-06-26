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
    public partial class customer_options : Form
    {
        public customer_options()
        {
            InitializeComponent();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from Product where Name='" + textBox9.Text.ToString() + "'", sqlConnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label4.Visible = true;
                label13.Visible = true;
                label13.Text = "ID: " + reader.GetValue(0).ToString();
                label13.Text += "\n";
                label13.Text = "Quantity: " + reader.GetValue(2).ToString();
                label13.Text += "\n";
                label13.Text += "Category: " + reader.GetValue(3).ToString();
                label13.Text += "\n";
                label13.Text += "price: " + reader.GetValue(4).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where username = '" + textBox10.Text.ToString() + "'", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show(" deleted successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("update Customer set Email='" + textBox18.Text.ToString() + "',Cus_Address='" + textBox14.Text.ToString() + "' where  username='" + textBox16.Text.ToString() + "'", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show(" updated successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(" select UserID from Customer where username='"+textBox4.Text.ToString()+"'", sqlConnection);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("insert into Orders values('" + textBox7.Text.ToString() + "','"+textBox2.Text.ToString()+"','" + textBox3.Text.ToString()+"','"+textBox6.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+cmd.ExecuteScalar()+"')", sqlConnection);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("insert into OrderDetails values('"+textBox7.Text.ToString()+"','" + textBox1.Text.ToString() + "',100)", sqlConnection);
            cmd2.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Succeeded");

        }
    }
}
