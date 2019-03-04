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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Please enter name");
            }
            else
            {
                con = new SqlConnection("Data Source=TAYYAB\\SQLEXPRESS;Initial Catalog=contacts;User ID=sa;Password=1234");
                con.Open();

                string query = "select * from condata where names = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();

                }
                else
                {
                    MessageBox.Show("Invalid name");
                }

                con.Close();
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                con = new SqlConnection("Data Source=TAYYAB\\SQLEXPRESS;Initial Catalog=contacts;User ID=sa;Password=1234");
                con.Open();

                SqlCommand cnd = new SqlCommand("UPDATE condata SET names='" + textBox2.Text + "',contact='" + textBox3.Text + "' WHERE names='" + textBox1.Text + "'", con);
                cnd.ExecuteNonQuery();

                con.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
