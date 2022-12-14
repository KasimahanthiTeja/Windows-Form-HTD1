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
    public partial class AddBooks : Form
    {
        public AddBooks()
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
                SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADDBOOKS", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into TBL_ADDBOOKS values(@BOOK_NAME, @AUTHOR_NAME, @QUANTITY, @GRADUATION_YEAR)", con);
                cmd.Parameters.AddWithValue("@BOOK_NAME", txtBook.Text);
                cmd.Parameters.AddWithValue("@AUTHOR_NAME", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@QUANTITY", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@GRADUATION_YEAR", txtYear.Text);
                int res = cmd.ExecuteNonQuery();
                if(res > 0)
                {
                    MessageBox.Show("Books added successfully");
                    txtBook.Text = "";
                    txtAuthor.Text = "";
                    txtQuantity.Text = "";
                    txtYear.Text = "";
                    GetData();
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
    }
}
