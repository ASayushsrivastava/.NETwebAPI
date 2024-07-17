using Restaurant_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restraunt_Managment_system
{
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
            Con = new Functions();
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else if (NameTb.Text == "Admin" || PasswordTb.Text == "Admin")
            {
                Users Obj = new Users();
                Obj.Show();
                this.Hide();
            }
            else
            {
                string Query = "select * from UsersTable where UName = '{0}' and UPass = '{1}'";
                Query = string.Format(Query, NameTb.Text, PasswordTb.Text);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    Billing Obj = new Billing();
                    Obj.Show();
                    this.Hide();
                }
            }
        }
    }
}
