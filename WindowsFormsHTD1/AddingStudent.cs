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
    public partial class AddingStudent : Form
    {
        public AddingStudent()
        {
            InitializeComponent();
            GetStudent();
        }
        public void GetStudent()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBL_STD", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                string value = "";
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                    value = radioButton1.Text;
                else
                    value = radioButton2.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into TBL_STD values(@STUDENT_ROLLNO, @STUDENT_NAME, @COURSE)", con);
                cmd.Parameters.AddWithValue("@STUDENT_ROLLNO", txtStdRollNo.Text);
                cmd.Parameters.AddWithValue("@STUDENT_NAME", txtStdName.Text);
                cmd.Parameters.AddWithValue("@COURSE", value);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Books added successfully");
                    txtStdRollNo.Text = "";
                    txtStdName.Text = "";
                    GetStudent();
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
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
