using Restaurant_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restraunt_Managment_system
{
    public partial class Billing : Form
    {
        Functions Con;

        public Billing()
        {
            Con = new Functions();
            InitializeComponent();
            ShowItems();
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

        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int n = 0;
        int GrandTotal = 0;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Details!!!");
            }
            else
            {
                int Total = Convert.ToInt32(PriceTb.Text) * Convert.ToInt32(QtyTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ItemTb.Text;
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QtyTb.Text;
                newRow.Cells[4].Value = "Rs " + Total;
                BillDGV.Rows.Add(newRow);
                n++;
                GrandTotal = GrandTotal + Total;
                GrandTotalBill.Text = "Rs " + GrandTotal;
            }
        }
        int key = 0;
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            //CatCb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            if (ItemTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void GrandTotalBill_Click(object sender, EventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
