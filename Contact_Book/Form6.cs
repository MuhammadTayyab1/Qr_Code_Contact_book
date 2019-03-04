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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con = new SqlConnection("Data Source=TAYYAB\\SQLEXPRESS;Initial Catalog=contacts;User ID=sa;Password=1234");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from condata where names='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            else
            {
                MessageBox.Show("please enter correct name");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = "";
            string contact = "";

            con = new SqlConnection("Data Source=TAYYAB\\SQLEXPRESS;Initial Catalog=contacts;User ID=sa;Password=1234");
            con.Open();

            string query = "select * from condata where names = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                name = reader[1].ToString();
                contact = reader[2].ToString();

            }
            else
            {
                MessageBox.Show("Invalid name");
            }

            con.Close();
            reader.Close();

            string save = name + "\n" + contact;

            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qrcode.Draw(save, 50);

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
