//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my create person form
//******************************************
//******************************************

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
    public partial class frmCreateAcct : Form
    {
        public static string strPersonID;
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public static string strInsert;
        public frmCreateAcct()
        {
            InitializeComponent();
        }

        private void frmCreateAcct_Load(object sender, EventArgs e)
        {
            cbxTitle.Items.Add("Mr.");
            cbxTitle.Items.Add("Ms.");
            cbxTitle.Items.Add("Dr.");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string strTitle = "";
            //insert a new Person record after validating zip, phone and email
            if (cbxTitle.SelectedIndex != -1)
            {
                strTitle = cbxTitle.SelectedItem.ToString();
            }
            else
            {
                strTitle = "";
            }
            string strFirstName = tbxFirst.Text.Trim();
            string strLastName = tbxLast.Text.Trim();
            string strMiddleName = tbxMiddle.Text.Trim();
            string strSuffix = tbxSuffix.Text.Trim();
            string strAddress1 = tbxAddress1.Text.Trim();
            string strAddress2 = tbxAddress2.Text.Trim();
            string strAddress3 = tbxAddress3.Text.Trim();
            string strCity = tbxCity.Text.Trim();
            string strZipCode = tbxZipCode.Text.Trim();
            string strState = tbxState.Text.Trim();
            string strPrimPhone = tbxPrimPhone.Text.Trim();
            string strSecondPhone = tbxSecPhone.Text.Trim();
            string strEmail = tbxEmail.Text.Trim();
            try
            {
                if (!clsValidation.ValidZip(strZipCode))
                {
                    MessageBox.Show("Zip Code not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidEmail(strEmail) && strEmail != "")
                {
                    MessageBox.Show("Email not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidPhone(strPrimPhone) && strPrimPhone != "")
                {
                    MessageBox.Show("Primary Phone not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidPhone(strSecondPhone) && strSecondPhone != "")
                {
                    MessageBox.Show("Second Phone not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbxFirst.Text == "")
                    {
                    MessageBox.Show("First Name cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    }
                else if(tbxLast.Text == "")
                {
                    MessageBox.Show("Last Name cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(tbxAddress1.Text == "")
                {
                    MessageBox.Show("Address 1 cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(tbxCity.Text == "")
                {
                    MessageBox.Show("City cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(tbxZipCode.Text == "")
                {
                    MessageBox.Show("Zip Code cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxState.Text == "")
                {
                    MessageBox.Show("State cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                strInsert = "INSERT INTO tekelle21fa2332.Person VALUES ('" + strTitle + "', '" + strFirstName + "', '" + strMiddleName +
                   "', '" + strLastName + "', '" + strSuffix + "', '" + strAddress1 + "', '" + strAddress2 + "', '" + strAddress3 +
                   "', '" + strCity + "', '" + strZipCode + "', '" + strState + "', '" + strEmail + "', '" + strPrimPhone + "', '" +
                   strSecondPhone + "', NULL, NULL, 'Customer');";
                //MessageBox.Show(strInsert);
                //Get Person ID to pass to next form to create LogOn info
                string strPersonIDQuery = "SELECT MAX(PersonID) FROM tekelle21fa2332.Person;";
                strPersonID = clsSQL.DatabaseCommandLogon(strPersonIDQuery);
                //MessageBox.Show(strPersonID);
                this.Hide();
                frmCreateAcct2 createAcct2 = new frmCreateAcct2();
                createAcct2.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxPrimPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((int)e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxSecPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((int)e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((int)e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
