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
    public partial class ReturnBooks : Form
    {
        int Reference_ID;
        public ReturnBooks()
        {
            InitializeComponent();
            GetData();
        }
        public void GetData()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ASSIGNBOOKS", con);
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
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Reference_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update TBL_ASSIGNING set STATUS = @STATUS where REFERENCE_ID = @REFERENCE_ID", con);
                cmd.Parameters.AddWithValue("@STATUS", 0);
                cmd.Parameters.AddWithValue("@REFERENCE_ID", Reference_ID);
                int res = cmd.ExecuteNonQuery();
                if(res > 0)
                {
                    MessageBox.Show("Books returned successfully");
                    GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GetData();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
