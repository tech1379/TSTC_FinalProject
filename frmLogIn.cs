//******************************************
//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my login screen
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
using System.Data.SqlClient;

namespace FA21_Final_Project
{
    public partial class frmLogIn : Form
    {
        //variables 
        int intToggle = 0;
        public static string strLogInName;
        public static string strPersonID;
        public static bool boolHasAccount = false;
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
                    "Please inform the Program Developer that the following error occurred: \n\n\n";


        public frmLogIn()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                hlpMain.HelpNamespace = Application.StartupPath + "\\LogOnHelp.chm";
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int intFormControl;
            try
            {
                string strUserName = tbxLogIn.Text.ToUpper();
                string strPassword = tbxPassword.Text;
                if (strUserName == "")
                {
                    MessageBox.Show("UserName cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(strPassword == "")
                {
                    MessageBox.Show("Password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                intFormControl = clsLogon.Verify(strUserName, strPassword, ref strPersonID);
                if (intFormControl == 1)
                {
                    MessageBox.Show("Managers");
                }
                else if (intFormControl == 2)
                {
                    MessageBox.Show("Employees");
                }
                else if (intFormControl == 3)
                { 
                    boolHasAccount = true;
                    this.Hide();
                    frmMain customer = new frmMain();
                    customer.ShowDialog();
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pbxEye_Click(object sender, EventArgs e)
        {
            if (intToggle % 2 == 0)
            {
                tbxPassword.PasswordChar = '\0';
                intToggle++;
            }
            else
            {
                tbxPassword.PasswordChar = '*';
                intToggle++;
            }
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            if (tbxLogIn.Text == "")
            {
                MessageBox.Show("You must enter a username!", "Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            strLogInName = tbxLogIn.Text.ToUpper();
            bool boolVerify = clsLogon.Reset(strLogInName);
            if (boolVerify == true)
            {
                this.Hide();
                frmPassword password = new frmPassword();
                password.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Username!", "User Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblWebsite_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.tekskennels.com/");
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCreateAcct createAcct = new frmCreateAcct();
            createAcct.ShowDialog();
            
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpMain.HelpNamespace);
        }

        private void lblInventory_Click(object sender, EventArgs e)
        {
            boolHasAccount = false;
            frmMain customer = new frmMain();
            customer.ShowDialog();
        }
    }
}
