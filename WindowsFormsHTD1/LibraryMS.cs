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
    public partial class LibraryMS : Form
    {
        public LibraryMS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBooks obj = new AddBooks();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddingStudent obj1 = new AddingStudent();
            obj1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssignBooks obj2 = new AssignBooks();
            obj2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReturnBooks obj3 = new ReturnBooks();
            obj3.ShowDialog();
        }
    }
}
