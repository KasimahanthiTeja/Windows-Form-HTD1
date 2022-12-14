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
    public partial class DatabyID : Form
    {
        public DatabyID()
        {
            InitializeComponent();
            GetSno();
        }
        public void GetSno()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FIXITYEMP", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "Sno";
                comboBox1.ValueMember = "Sno";
                comboBox1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_FIXITYEMP where Sno = @Sno", con);
                cmd.Parameters.AddWithValue("@Sno", comboBox1.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    txtName.Text = dr["NAME"].ToString();
                    txtEmail.Text = dr["EMAIL"].ToString();
                    dateTimePicker_dob.Text = dr["DOB"].ToString();
                    txtSalary.Text = dr["SALARY"].ToString();
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
