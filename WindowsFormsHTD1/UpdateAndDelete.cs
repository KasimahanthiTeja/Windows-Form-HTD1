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
    public partial class UpdateAndDelete : Form
    {
        int SNO;
        public UpdateAndDelete()
        {
            InitializeComponent();
            GetUD();
        }
        public void GetUD()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BYID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
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
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker_dob.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            SNO = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_GETBYID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dateTimePicker_dob.Text));
                cmd.Parameters.AddWithValue("@SNO", SNO);
                int res = cmd.ExecuteNonQuery();
                if(res > 0)
                {
                    MessageBox.Show("Updated Successfully");
                    txtName.Text = "";
                    txtEmail.Text = "";
                    dateTimePicker_dob.Text = "";
                    GetUD();
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DELETE_GETBYID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SNO", SNO);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Deleted Successfully");
                    txtName.Text = "";
                    txtEmail.Text = "";
                    GetUD();
                }
            }
            catch(Exception ex)
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
