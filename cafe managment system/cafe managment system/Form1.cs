using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

namespace cafe_managment_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\Documents\library reception.mdf"";Integrated Security=True;Connect Timeout=30");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            // declare a variable to count the rows
            int i = 0;
            // create a sql command
            SqlCommand cmd= new SqlCommand("select * from Users where Name ='"+ textBox1.Text+ "' and Password ='"+ textBox2.Text+"'",Con);
            cmd.ExecuteNonQuery();
            //create a data table to store the data from the query
            DataTable dt = new DataTable();
            //create a dataadapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            //using count var to match the name & password
            if (i == 0)
            {
                MessageBox.Show("Wrong username and password");
            }
            else
            {
                //MessageBox.Show("Logined Successfully");
                this.Hide();
                Welcome_page F2 = new Welcome_page();
                F2.Show();
            }
            Con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
