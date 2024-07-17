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
    public partial class Items : Form
    {
        Functions Con;

        public Items()
        {
            Con = new Functions();
            InitializeComponent();
            ShowItems();
            GetCategories();
        }


        private void ShowItems()
        {
            try
            {
                string Query = "select * from ItemTable";
                ItemsList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetCategories()
        {
            try
            {
                string Query = "select * from CategoryTable";
                CatCb.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
                CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
                CatCb.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(PriceTb.Text) || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Category = CatCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Text);

                    string Query = string.Format("insert into ItemTable (ItName, ItCategory, ItPrice ) values ('{0}', '{1}', {2})", Name, Category, Price);

                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item added!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(PriceTb.Text) || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Category = CatCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Text);

                    string Query = "Update ItemTable set ItName = '{0}' , ItPrice = {1} , ItCategory = '{2}' where ItNum = {3}";
                    Query = string.Format(Query, Name, Price, Category, key);
                    Con.SetData(Query);
                    ShowItems();
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
                    string Category = CatCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Text);

                    string Query = "delete from ItemTable where ItNum = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item deleted!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserLbl_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {
            Category Obj = new Category();
            Obj.Show();
            this.Hide();
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
