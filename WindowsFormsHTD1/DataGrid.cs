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
    public partial class DataGrid : Form
    {
        public DataGrid()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-NJ2RS45Q;Initial catalog=NORTHWND;user id=sa;password=123456");

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_GETALLORDERSDATA", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
