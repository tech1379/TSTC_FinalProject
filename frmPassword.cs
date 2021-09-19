//******************************************
//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my password reset screen
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
    public partial class frmPassword : Form
    {
        string strLogInName = frmMain.strLogInName;
        int intToggle1 = 0;
        int intToggle2 = 0;
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmPassword()
        {
            InitializeComponent();
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            try
            {
                lblSC1.Text = clsLogon.GetSecurityQuestion1(strLogInName);
                lblSC2.Text = clsLogon.GetSecurityQuestion2(strLogInName);
                lblSC3.Text = clsLogon.GetSecurityQuestion3(strLogInName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void pbxPass1_Click(object sender, EventArgs e)
        {
            if (intToggle1 % 2 == 0)
            {
                tbxPassword.PasswordChar = '\0';
                intToggle1++;
            }
            else
            {
                tbxPassword.PasswordChar = '*';
                intToggle1++;
            }
        }

        private void pbxPass2_Click(object sender, EventArgs e)
        {
            if (intToggle2 % 2 == 0)
            {
                tbxConfirm.PasswordChar = '\0';
                intToggle2++;
            }
            else
            {
                tbxConfirm.PasswordChar = '*';
                intToggle2++;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //check passwords if they match, then verify password, then verify security answers, then update db password
            try
            {
                string strPassword = tbxPassword.Text;
                string strPassword2 = tbxConfirm.Text;
                if (strPassword != strPassword2)
                {
                    MessageBox.Show("Passwords do not match. Try Again!", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool boolPassword = false;
                boolPassword = clsLogon.PasswordRequirements(strPassword);
                if (boolPassword)
                {
                    string strSecurityAnswer1 = clsLogon.GetSecurityAnswer1(strLogInName);
                    string strSecurityAnswer2 = clsLogon.GetSecurityAnswer2(strLogInName);
                    string strSecurityAnswer3 = clsLogon.GetSecurityAnswer3(strLogInName);

                    if (tbxAn1.Text.ToUpper() == strSecurityAnswer1.ToUpper() && tbxAn2.Text.ToUpper() == strSecurityAnswer2.ToUpper() && tbxAn3.Text.ToUpper() == strSecurityAnswer3.ToUpper())
                    {
                        string strUpdateQuery = "UPDATE tekelle21fa2332.Logon SET Password = '" + strPassword + "' WHERE LogonName = '" + strLogInName + "';";
                        clsSQL.UpdateDatabase(strUpdateQuery);
                        MessageBox.Show("Password Changed.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        frmMain main = new frmMain();
                        main.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Password Not Changed.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Password not correct format!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
