using Restaurant_Management_System;
using System.Text.RegularExpressions;

namespace Restraunt_Managment_system
{
    public partial class Users : Form
    {

        Functions Con;
        public Users()
        {
            Con = new Functions();
            InitializeComponent();
            ShowUsers();

        }


        private void ShowUsers()
        {
            try
            {
                string Query = "select * from UsersTable";
                UsersList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || GenCb.SelectedIndex == -1 || PasswordTb.Text == "" || AddTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Address = AddTb.Text;


                    string Query = "insert into UsersTable values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Name, Gender, Password, Phone, Address);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User added!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void UsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = UsersList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = UsersList.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTb.Text = UsersList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = UsersList.SelectedRows[0].Cells[4].Value.ToString();
            AddTb.Text = UsersList.SelectedRows[0].Cells[5].Value.ToString();

            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UsersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) || GenCb.SelectedIndex == -1 || string.IsNullOrEmpty(PasswordTb.Text) || string.IsNullOrEmpty(AddTb.Text) || string.IsNullOrEmpty(PhoneTb.Text))
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Address = AddTb.Text;

                    string Query = "Update UsersTable set UName='{0}',UGen='{1}',UPass='{2}',UPhone='{3}',UAddress='{4}' where UId = {5}";
                    Query = string.Format(Query, Name, Gender, Password, Phone, Address, key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("Item updated!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Address = AddTb.Text;

                    string Query = "Delete from UsersTable where UId ={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Deleted!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ItemLbl_Click_1(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {
            Category Obj = new Category();
            Obj.Show();
            this.Hide();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
