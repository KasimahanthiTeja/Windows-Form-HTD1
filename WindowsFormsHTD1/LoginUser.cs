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
    public partial class LoginUser : Form
    {
        public LoginUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_FIXITYEMP where EMAIL = @EMAIL AND DOB = @DOB", con);
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dateTimePicker1_dob.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Login Successful");
                }
                else
                {
                    MessageBox.Show("Emailid or password isa incorrect");
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
