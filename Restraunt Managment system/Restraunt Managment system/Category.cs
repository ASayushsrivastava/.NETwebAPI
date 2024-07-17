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
    public partial class Category : Form
    {
        Functions Con;
        public Category()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }

        private void ShowCategories()
        {
            try
            {
                string Query = "select * from CategoryTable";
                CategoriesList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void AddcatBtn_Click(object sender, EventArgs e)
        {
            if (CatNametb.Text == "" || Desctb.Text == "")
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Category = CatNametb.Text;
                    string Desc = Desctb.Text;
                    string Query = "insert into CategoryTable values('{0}','{1}')";
                    Query = string.Format(Query, Category, Desc);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("category added!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }
        int key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNametb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            Desctb.Text = CategoriesList.SelectedRows[0].Cells[2].Value.ToString();
            if (CatNametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditcatBtn_Click(object sender, EventArgs e)
        {
            if (CatNametb.Text == "" || Desctb.Text == "")
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Category = CatNametb.Text;
                    string Desc = Desctb.Text;
                    string Query = "Update CategoryTable set CatName = '{0}', CatDesc = '{1}' where CatCode ={2}";
                    Query = string.Format(Query, Category, Desc, key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("category Updated!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DelcatBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                try
                {
                    string Category = CatNametb.Text;
                    string Desc = Desctb.Text;
                    string Query = "Delete from CategoryTable where CatCode ={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("category Deleted!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void UserLbl_Click_1(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void ItemLbl_Click_1(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
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
