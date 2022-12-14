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
    public partial class AssignBooks : Form
    {
        public AssignBooks()
        {
            InitializeComponent();
            Getbooks();
            GetStudent();
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
        public void Getbooks()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADDBOOKS", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "BOOK_NAME";
                comboBox1.ValueMember = "BOOKID";
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
        public void GetStudent()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBL_STD", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox2.DisplayMember = "STUDENT_ROLLNO";
                comboBox2.ValueMember = "STUDENT_ID";
                comboBox2.DataSource = dt;
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
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into TBL_ASSIGNING values(@BOOK_ID, @STUDENT_ID, @STATUS, @DOI)", con);
                cmd.Parameters.AddWithValue("@BOOK_ID", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@STUDENT_ID", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@STATUS", 1);
                cmd.Parameters.AddWithValue("@DOI", Convert.ToDateTime(dateTimePicker1_DOI.Text));
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Books assigned successfully");
                    GetData();
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
