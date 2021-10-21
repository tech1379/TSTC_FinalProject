using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmAdd : Form
    {
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxItemName.Text == "")
                {
                    MessageBox.Show("Item Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxItemName.Focus();
                    return;
                }
                else if (tbxItemDesc.Text == "")
                {
                    MessageBox.Show("Item Description cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxItemDesc.Focus();
                    return;
                }
                else if (tbxRetailPrice.Text == "")
                {
                    MessageBox.Show("Retail Price cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxRetailPrice.Focus();
                    return;
                }
                else if (tbxCost.Text == "")
                {
                    MessageBox.Show("Cost cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxCost.Focus();
                    return;
                }
                else if (tbxQuantity.Text == "")
                {
                    MessageBox.Show("Quantity cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxQuantity.Focus();
                    return;
                }
                string strItemName = tbxItemName.Text;
                string strItemDesc = tbxItemDesc.Text;
                decimal decRetailPrice = Convert.ToDecimal(tbxRetailPrice.Text);
                decimal decCost = Convert.ToDecimal(tbxCost.Text);
                int intQuantity = Convert.ToInt32(tbxQuantity.Text);
                clsSQL.DatabaseCommandAddItem(strItemName, strItemDesc, decRetailPrice, decCost, intQuantity);
                this.Hide();
                Application.OpenForms["frmManager"].Close();
                frmManager frmManagerNew = new frmManager();
                frmManagerNew.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == ' ' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxItemDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == ' ' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
