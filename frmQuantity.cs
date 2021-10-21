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
    public partial class frmQuantity : Form
    {
        public static int intInventoryID = frmManager.intInventoryID;
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmQuantity()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["frmManager"].Show();
        }

        

        private void tbxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxInput.Text == "")
                {
                    MessageBox.Show("You must enter a quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strQuantity = tbxInput.Text;
                if (!clsValidation.ValidPosNegInteger(strQuantity))
                {
                    MessageBox.Show("You must input a positive or negative integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxInput.Clear();
                    tbxInput.Focus();
                    return;
                }
                int intQuantity = Convert.ToInt32(strQuantity);
                string strQuantityUpdateQuery = "UPDATE tekelle21fa2332.Inventory SET Quantity = Quantity + " + intQuantity + " WHERE InventoryID = " + intInventoryID + ";";
                clsSQL.UpdateDatabase(strQuantityUpdateQuery);
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

        private void frmQuantity_Load(object sender, EventArgs e)
        {

        }
    }
}
