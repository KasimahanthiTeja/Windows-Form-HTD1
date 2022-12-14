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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClient_Name.Text))
            {
                MessageBox.Show("Client_Name cannot be Empty");
            }
            else if (string.IsNullOrEmpty(txtPayment_Mode.Text))
            {
                MessageBox.Show("Payment_Mode  cannot be Empty");
            }
            else if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("DOP cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtInvoice_Type.Text))
            {
                MessageBox.Show("Invoice Type cannot be Empty");
            }
            else if (string.IsNullOrEmpty(txtDepartment_name.Text))
            {
                MessageBox.Show("Department_name cannot be Empty");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data source=LAPTOP-NJ2RS45Q; Initial catalog=DB_HTDBATCH1; user id=sa; password=123456");
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into tbl_invoices values(@Client_Name, @Payment_Mode, @DOP, @Invoice_type, @Department_name)", con);
                    cmd.Parameters.AddWithValue("@Client_Name", txtClient_Name.Text);
                    cmd.Parameters.AddWithValue("@Payment_Mode", txtPayment_Mode.Text);
                    cmd.Parameters.AddWithValue("@DOP", Convert.ToDateTime(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@Invoice_Type", txtInvoice_Type.Text);
                    cmd.Parameters.AddWithValue("@Department_name", txtDepartment_name.Text);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Data inserted successsfully");
                        txtClient_Name.Text = "";
                        txtPayment_Mode.Text = "";
                        txtInvoice_Type.Text = "";
                        txtDepartment_name.Text = "";
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
}

//private void button1_Click(object sender, EventArgs e)
//{
//    if (string.IsNullOrEmpty(txtname.Text))
//    {
//        MessageBox.Show("Name cant be Null");
//    }
//    else if (System.Text.RegularExpressions.Regex.IsMatch(txtmob.Text, "[^0-9]"))
//    {
//        MessageBox.Show("Please enter only numbers.");
//        txtmob.Text = txtmob.Text.Remove(txtmob.Text.Length - 1);
//    }
//    else
//    {
//        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3ODGK3L;Initial Catalog=DB_HTDBATCH1;User id=sa;Password=123456");
//        try
//        {
//            string value = "";
//            bool isChecked = radioButton_Male.Checked;
//            if (isChecked)
//                value = radioButton_Male.Text;
//            else
//                value = radioButton_Female.Text;
//            con.Open();
//            SqlCommand cmd = new SqlCommand("SP_INSERT_NEW_STDDATA", con);
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@name", txtname.Text);
//            cmd.Parameters.AddWithValue("@emailid", txtemail.Text);
//            cmd.Parameters.AddWithValue("@password", txtpwd.Text);
//            cmd.Parameters.AddWithValue("@mobile", Convert.ToInt64(txtmob.Text));
//            cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(dob.Text));
//            cmd.Parameters.AddWithValue("@gender", value);
//            int res = cmd.ExecuteNonQuery(); // if inserted res will be 1
//            if (res > 0)
//            {
//                MessageBox.Show("Insertred Successfully");
//                txtname.Text = "";
//                txtemail.Text = "";
//                txtpwd.Text = "";
//                txtmob.Text = "";
//            }
//            else
//            {
//                MessageBox.Show("Something Went Wrong");
//            }




//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            con.Close();
//        }
//    }
//}