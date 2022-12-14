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

namespace WindowsFormsHTD1
{
    public partial class FillDatabyID : Form
    {
        public FillDatabyID()
        {
            InitializeComponent();
            CustomerId();
        }
        public void CustomerId()
        {
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-NJ2RS45Q; Initial Catalog = NORTHWND; User id = sa; Password = 123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Orders", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "CustomerId";
                comboBox1.ValueMember = "CustomerId";
                comboBox1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-NJ2RS45Q; Initial Catalog = NORTHWND; user id = sa; Password = 123456");
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders where CustomerId = @Customerid", con);
                cmd.Parameters.AddWithValue("@Customerid", comboBox1.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
