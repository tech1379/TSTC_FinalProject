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
        
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public static string strInsert;
        List<clsState> lstState = new List<clsState>();
        public static bool boolAddManager = frmManager.boolAddManager;
        public static bool boolEditManager = frmManager.boolEditManager;
        public static string strState = frmManager.strState;
        public static int intPersonID = frmManager.intPersonID;
        public frmCreateAcct()
        {
            InitializeComponent();
        }

        private void frmCreateAcct_Load(object sender, EventArgs e)
        {
            try
            {
                hlpMain.HelpNamespace = Application.StartupPath + "\\CreateAcct.chm";
                cbxTitle.Items.Add("Mr.");
                cbxTitle.Items.Add("Ms.");
                cbxTitle.Items.Add("Dr.");
                lstState = clsSQL.LoadState();
                for (int i = 0; i < lstState.Count; i++)
                {
                    cbxState.Items.Add(lstState[i].strStateName);
                }
                if(boolEditManager == true)
                {
                    clsSQL.DatabaseCommandManagers(tbxFirst, tbxMiddle, tbxLast, tbxSuffix, tbxAddress1, tbxAddress2,
                        tbxAddress3, tbxCity, tbxZipCode, tbxEmail, tbxPrimPhone, tbxSecPhone, intPersonID);
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            
            string strPrimPhone = tbxPrimPhone.Text.Trim();
            string strSecondPhone = tbxSecPhone.Text.Trim();
            string strEmail = tbxEmail.Text.Trim();
            try
            {
                
                if (tbxFirst.Text == "")
                    {
                    MessageBox.Show("First Name cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxFirst.Focus();
                    return;
                    }
                else if(tbxLast.Text == "")
                {
                    MessageBox.Show("Last Name cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxLast.Focus();
                    return;
                }
                else if(tbxAddress1.Text == "")
                {
                    MessageBox.Show("Address 1 cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxAddress1.Focus();
                    return;
                }
                else if(tbxCity.Text == "")
                {
                    MessageBox.Show("City cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxCity.Focus();
                    return;
                }
                else if(tbxZipCode.Text == "")
                {
                    MessageBox.Show("Zip Code cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxZipCode.Focus();
                    return;
                }
                else if (cbxState.SelectedIndex == -1)
                {
                    MessageBox.Show("State cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxState.Focus();
                    return;
                }
                if (!clsValidation.ValidZip(strZipCode))
                {
                    MessageBox.Show("Zip Code not entered Correctly. Format 99999 or 99999-9999.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxZipCode.Clear();
                    tbxZipCode.Focus();
                    return;
                }
                if (!clsValidation.ValidEmail(strEmail) && strEmail != "")
                {
                    MessageBox.Show("Email not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxEmail.Clear();
                    tbxEmail.Focus();
                    return;
                }
                if (!clsValidation.ValidPhone(strPrimPhone) && strPrimPhone != "")
                {
                    MessageBox.Show("Primary Phone not entered Correctly. Format 999-999-9999.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxPrimPhone.Clear();
                    tbxPrimPhone.Focus();
                    return;
                }
                if (!clsValidation.ValidPhone(strSecondPhone) && strSecondPhone != "")
                {
                    MessageBox.Show("Second Phone not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxSecPhone.Clear();
                    tbxSecPhone.Focus();
                    return;
                }
                string strState = lstState[(cbxState.SelectedIndex)].strStateAbbv.ToString();
                if(boolAddManager == true)
                {
                    strInsert = "INSERT INTO tekelle21fa2332.Person VALUES ('" + strTitle + "', '" + strFirstName + "', '" + strMiddleName +
                    "', '" + strLastName + "', '" + strSuffix + "', '" + strAddress1 + "', '" + strAddress2 + "', '" + strAddress3 +
                    "', '" + strCity + "', '" + strZipCode + "', '" + strState + "', '" + strEmail + "', '" + strPrimPhone + "', '" +
                    strSecondPhone + "', NULL, NULL, 'Manager');";

                }
                else
                {
                    strInsert = "INSERT INTO tekelle21fa2332.Person VALUES ('" + strTitle + "', '" + strFirstName + "', '" + strMiddleName +
                  "', '" + strLastName + "', '" + strSuffix + "', '" + strAddress1 + "', '" + strAddress2 + "', '" + strAddress3 +
                  "', '" + strCity + "', '" + strZipCode + "', '" + strState + "', '" + strEmail + "', '" + strPrimPhone + "', '" +
                  strSecondPhone + "', NULL, NULL, 'Customer');";
                }
               
                
                this.Hide();
                frmCreateAcct2 frmCreateAcct2 = new frmCreateAcct2();
                frmCreateAcct2.ShowDialog();
                
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

        private void tbxAddress1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxAddress2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxAddress3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            { //acceptable keystrokes
                e.Handled = true;
            }
            else if((int)e.KeyChar == 8)
            {
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

        private void frmCreateAcct_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (boolAddManager == true || boolEditManager == true)
                {
                    this.Hide();
                    Application.OpenForms["frmManager"].Close();
                    frmManager frmManagerNew = new frmManager();
                    frmManagerNew.ShowDialog();
                }
                else
                {
                    this.Hide();
                    frmLogIn frmLogInMain = new frmLogIn();
                    frmLogInMain.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblHelp2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpMain.HelpNamespace);
        }

        private void tbxFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            { //acceptable keystrokes
                e.Handled = true;
            }
            else if ((int)e.KeyChar == 8)
            {
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

        private void tbxMiddle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            { //acceptable keystrokes
                e.Handled = true;
            }
            else if ((int)e.KeyChar == 8)
            {
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

        private void tbxLast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            { //acceptable keystrokes
                e.Handled = true;
            }
            else if ((int)e.KeyChar == 8)
            {
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
    }
}
