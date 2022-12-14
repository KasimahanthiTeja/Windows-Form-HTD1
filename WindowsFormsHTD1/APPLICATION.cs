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
    public partial class APPLICATION : Form
    {
        public APPLICATION()
        {
            InitializeComponent();
        }

        private void APPLICATION_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirst.Text))
            {
                MessageBox.Show("First name cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtLast.Text))
            {
                MessageBox.Show("Last name cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtPosition.Text))
            {
                MessageBox.Show("Position cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtSal.Text))
            {
                MessageBox.Show("Salary field cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone number  cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtOutlook.Text))
            {
                MessageBox.Show("Outlook account cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtLast_Company.Text))
            {
                MessageBox.Show("Last company of your work cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtReference.Text))
            {
                MessageBox.Show("Reference field cannot be empty");
            }
            else
            {

                SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into TBL_APPLICATION values(@First_Name, @Last_Name, @Email, @Position, @Salary_Requirement, @Start_Date, @Phone_no, @Outlook_Account, @Last_company_of_your_work, @Reference", con);
                    cmd.Parameters.AddWithValue("@First_Name", txtFirst.Text);
                    cmd.Parameters.AddWithValue("@Last_Name", txtLast.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
                    cmd.Parameters.AddWithValue("@Salary_Requiorements", Convert.ToInt32(txtSal.Text));
                    cmd.Parameters.AddWithValue("@Start_Date", Convert.ToDateTime(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@Phone_no", Convert.ToInt64(txtPhone.Text));
                    cmd.Parameters.AddWithValue("@Outlook_Account", txtOutlook.Text);
                    cmd.Parameters.AddWithValue("@Last_company_of_your_work", txtLast_Company.Text);
                    cmd.Parameters.AddWithValue("@Reference", txtReference.Text);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Applied successfuly");
                        txtFirst.Text = "";
                        txtLast.Text = "";
                        txtEmail.Text = "";
                        txtPosition.Text = "";
                        txtSal.Text = "";
                        txtPhone.Text = "";
                        txtOutlook.Text = "";
                        txtLast_Company.Text = "";
                        txtReference.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Missed some value");
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
