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
    public partial class admin_options : Form
    {
        public admin_options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into Product values('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox2.Text.ToString() + "')", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show(" add succssfully");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from Product where Name='"+textBox9.Text.ToString()+"'", sqlConnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                label5.Visible = true;
                label13.Visible = true;
                label13.Text ="Quantity: "+ reader.GetValue(2).ToString();
                label13.Text += "\n";
                label13.Text +="Category: "+ reader.GetValue(3).ToString();
                label13.Text += "\n";
                label13.Text += "price: " + reader.GetValue(4).ToString();
            }
           
            sqlConnection.Close();
          
          

        }

        private void admin_options_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'super_MarketDataSet1.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.super_MarketDataSet1.Customer);
            // TODO: This line of code loads data into the 'super_MarketDataSet1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.super_MarketDataSet1.Product);
            // TODO: This line of code loads data into the 'super_MarketDataSet.OrderDetails' table. You can move, or remove it, as needed.
            this.orderDetailsTableAdapter.Fill(this.super_MarketDataSet.OrderDetails);
            // TODO: This line of code loads data into the 'super_MarketDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.super_MarketDataSet.Product);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("update Product set price='"+textBox7.Text.ToString()+"',Quantity='"+textBox5.Text.ToString()+"' where  Name='"+textBox8.Text.ToString()+"'", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show(" updated successfully");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("delete from Product where Name = '"+textBox12.Text.ToString()+"'", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show(" deleted successfully");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            SqlCommand cmd = new SqlCommand("update Customer set Email='" + textBox18.Text.ToString() + "',Cus_Address='"+textBox14.Text.ToString()+"' where  username='" + textBox16.Text.ToString() + "'", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show(" updated successfully");
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select p.Name from Product p, OrderDetails o where p.productID = (Select o.productID from OrderDetails o group by o.productID having count(o.productID) = 2) group by p.Name; ", sqlConnection);
            label18.Text = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select p.Name from Product p where p.productID Not In (Select o.productID from OrderDetails o);", sqlConnection);
            label20.Text = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

     

        private void button10_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(" select top 1 TotalPrice, Customer.FirstName, Customer.LastName From Customer, Orders, OrderDetails where Customer.UserID = Orders.CustomerID and   Orders.OrderID = OrderDetails.OrderID and Orders.Month = 5 and Orders.Year = 2022", sqlConnection);
            label24.Text = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(" select count( Category ) as NumberOfPurchase,Category from product, orderdetails,Orders,customer where orders.OrderID = OrderDetails.OrderID and product.ProductID = OrderDetails.ProductID and Customer.UserID = Orders.CustomerID group by category order by category desc", sqlConnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label25.Text =reader.GetString(1);

            }
            sqlConnection.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select count ( Customer.UserID) as NumberOfCustomers, product.Name, product.ProductID, product.Category,Product.price,Product.Quantity from product,   Customer ,orders,OrderDetails where Product.ProductID = OrderDetails.ProductID and Customer.UserID = Orders.CustomerID and OrderDetails.OrderID = Orders.OrderID group by  product.Name, product.Category, Product.price, product.ProductID, Product.Quantity order by NumberOfCustomers desc", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form a = new Form1();
            a.Show();
            this.Hide();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productTableAdapter.FillBy(this.super_MarketDataSet.Product);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productTableAdapter.FillBy1(this.super_MarketDataSet.Product);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select distinct FirstName,LastName,UserID,TotalPrice from Customer, Product,OrderDetails where Product.ProductID = OrderDetails.ProductID and OrderDetails.TotalPrice > 500", con)) 
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView4.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string constring = @"Data Source=DESKTOP-HBENP3U\SQLEXPRESS;Initial Catalog=Super_Market;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select c.FirstName from Customer c , Orders o where c.UserID=o.CustomerID and (o.year in ('2020', '2021') and(o.Month <= '5') and o.year!= '2022') group by c.FirstName; ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView5.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form a = new customer_signup();
            a.Show();
            this.Hide();
        }
    }
}
