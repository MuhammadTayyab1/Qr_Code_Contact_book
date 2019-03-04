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

namespace Contact_Book
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text!="")
            {
                con = new SqlConnection("Data Source=TAYYAB\\SQLEXPRESS;Initial Catalog=contacts;User ID=sa;Password=1234");
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into condata(names,contact)values('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Save sucessfully");
            }
            else
            {
                MessageBox.Show("please enter complete information");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
