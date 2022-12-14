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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name cannot be Empty");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email  cannot be Empty");
            }
            else if (string.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBox.Show("Sal cannot be Empty");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1;user id=sa;password=123456");
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBL_REGISTER VALUES(@NAME,@EMAIL,@SALARY,@DOB)", con);
                    cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dateTimePicker1.Text));
                    int res = cmd.ExecuteNonQuery();  // 1 if inserted 
                    if (res > 0)
                    {
                        MessageBox.Show("Inserted Successfully");
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtSalary.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("SOmething went Wrong!");
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
}
