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
    public partial class Library : Form
    {
        int SNO;
        public Library()
        {
            InitializeComponent();
            GetLib();
            StudentName();
        }
        public void GetLib()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_BOOKS_LIBRARY", con);
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
        public void StudentName()
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from LIBRARY", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "STUDENT_NAME";
                comboBox1.ValueMember = "STUDENT_NAME";
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
            if (string.IsNullOrEmpty(txtStudntID.Text))
            {
                MessageBox.Show("Student id cannot be empty");
            }
            else if(string.IsNullOrEmpty(txtStudntName.Text))
            {
                MessageBox.Show("Student name cannot be empty");
            }
            else if(string.IsNullOrEmpty(txtBookName.Text))
            {
                MessageBox.Show("Book name cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtAuthor.Text))
            {
                MessageBox.Show("Author name cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Quantity cannot be empty");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into LIBRARY values(@STUDENT_ID, @STUDENT_NAME, @BOOK_NAME, @AUTHOR_NAME, @DOI, @DOR, @QUANTITY)", con);
                    cmd.Parameters.AddWithValue("@STUDENT_ID", Convert.ToInt32(txtStudntID.Text));
                    cmd.Parameters.AddWithValue("@STUDENT_NAME", txtStudntName.Text);
                    cmd.Parameters.AddWithValue("@BOOK_NAME", txtBookName.Text);
                    cmd.Parameters.AddWithValue("@AUTHOR_NAME", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@DOI", Convert.ToDateTime(dateTimePicker_DOI.Text));
                    cmd.Parameters.AddWithValue("@DOR", Convert.ToDateTime(dateTimePicker_DOR.Text));
                    cmd.Parameters.AddWithValue("@QUANTITY", Convert.ToInt32( txtQuantity.Text));
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Successful");
                        txtStudntID.Text = "";
                        txtStudntName.Text = "";
                        txtBookName.Text = "";
                        txtAuthor.Text = "";
                        txtQuantity.Text = "";
                        GetLib();
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtStudntID.Text =  dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStudntName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBookName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAuthor.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker_DOI.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker_DOR.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuantity.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            SNO = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_LIBRARY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@STUDENT_ID", Convert.ToInt32(txtStudntID.Text));
                cmd.Parameters.AddWithValue("@STUDENT_NAME", txtStudntName.Text);
                cmd.Parameters.AddWithValue("@BOOK_NAME", txtBookName.Text);
                cmd.Parameters.AddWithValue("@AUTHOR_NAME", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@DOI", Convert.ToDateTime(dateTimePicker_DOI.Text));
                cmd.Parameters.AddWithValue("@DOR", Convert.ToDateTime(dateTimePicker_DOR.Text));
                cmd.Parameters.AddWithValue("@QUANTITY", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@SNO", SNO);
                int res = cmd.ExecuteNonQuery();
                if(res > 0)
                {
                    MessageBox.Show("Updated Successfully");
                    txtStudntID.Text = "";
                    txtStudntName.Text = "";
                    txtBookName.Text = "";
                    txtAuthor.Text = "";
                    txtQuantity.Text = "";
                    GetLib();
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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DELETE_LIBRARY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@STUDENT_ID", Convert.ToInt32(txtStudntID.Text));
                cmd.Parameters.AddWithValue("@STUDENT_NAME", txtStudntName.Text);
                cmd.Parameters.AddWithValue("@BOOK_NAME", txtBookName.Text);
                cmd.Parameters.AddWithValue("@AUTHOR_NAME", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@DOI", Convert.ToDateTime(dateTimePicker_DOI.Text));
                cmd.Parameters.AddWithValue("@DOR", Convert.ToDateTime(dateTimePicker_DOR.Text));
                cmd.Parameters.AddWithValue("@QUANTITY", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@SNO", SNO);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Deleted Successfully");
                    txtStudntID.Text = "";
                    txtStudntName.Text = "";
                    txtBookName.Text = "";
                    txtAuthor.Text = "";
                    txtQuantity.Text = "";
                    GetLib();
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa;password=123456");
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from LIBRARY where STUDENT_NAME = @STUDENT_NAME", con);
                cmd.Parameters.AddWithValue("@STUDENT_NAME", comboBox1.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
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
    }
}
