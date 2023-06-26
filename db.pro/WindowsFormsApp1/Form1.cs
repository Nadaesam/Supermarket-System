using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string con = @"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'supermarketDataSet.Products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter.Fill(this.supermarketDataSet.Products);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Products values('food',30,'food',60)",sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("succssful");*/
            Form c = new Admin_signup();
            c.Show();
            this.Hide();

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            Form c = new customer_signup();
            c.Show();
            this.Hide();
        }
    }
}
