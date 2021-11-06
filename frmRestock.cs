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
    public partial class frmRestock : Form
    {
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
            "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmRestock()
        {
            InitializeComponent();
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
                string strQuantityUpdateQuery = "INSERT INTO tekelle21fa2332.Restock VALUES(" + intQuantity + ");";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["frmManager"].Show();
        }
    }
}
