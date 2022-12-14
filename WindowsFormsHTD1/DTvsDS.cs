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
    public partial class DTvsDS : Form
    {
        public DTvsDS()
        {
            InitializeComponent();
            //ExonDatatable();
            ExonDataSet();
        }
        public void ExonDatatable()
        {
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-NJ2RS45Q;Initial catalog = NORTHWND; user id = sa; password = 123456");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from orders", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;



                SqlDataAdapter da1 = new SqlDataAdapter("select * from Products", con);
                da1.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ExonDataSet()
        {
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-NJ2RS45Q; Initial catalog = NORTHWND; user id = sa; password = 123456");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from orders", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "xyz");
                dataGridView1.DataSource = ds.Tables[0];



                SqlDataAdapter da1 = new SqlDataAdapter("select * from Products", con);
                da1.Fill(ds, "abc");
                dataGridView2.DataSource = ds.Tables[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
