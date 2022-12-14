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
    public partial class ASSSESSMENTS : Form
    {
        public ASSSESSMENTS()
        {
            InitializeComponent();
            gettask();
        }
        public void gettask()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1;user id=sa;password=123456");
            try
            {
                string value = "";
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                    value = radioButton1.Text;
                else
                    value = radioButton2.Text;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select Name from tbl_dept", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "Name";
                comboBox1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1;user id=sa;password=123456");
            try
            {
                string value = "";
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                    value = radioButton1.Text;
                else
                    value = radioButton2.Text;
                string value1 = "";
                if (this.checkBox1.Checked)
                {
                    value1 = value1 + this.checkBox1.Text + ",";
                }
                if (this.checkBox2.Checked)
                {
                    value1 = value1 + this.checkBox2.Text + ",";
                }
                if (this.checkBox3.Checked)
                {
                    value1 = value1 + this.checkBox3.Text + ",";
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GETTBL_TSK1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(txtUID.Text));
                cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", Convert.ToInt32(txtPassword.Text));
                cmd.Parameters.AddWithValue("@GENDER", value);
                cmd.Parameters.AddWithValue("@SALARY", Convert.ToInt32(txtSalary.Text));
                cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@Qualification", value1);
                cmd.Parameters.AddWithValue("@DEPARTMENT", comboBox1.Text);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Data has inserted successfully");
                    txtUID.Text = "";
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtSalary.Text = "";
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
                conn.Close();
            }
        }
    }
}
