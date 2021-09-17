﻿//******************************************
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
    public partial class frmMain : Form
    {
        //variables 
        int intToggle = 0;
        public static string strLogInName;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserName = tbxLogIn.Text;
            string strPassword = tbxPassword.Text;
            clsLogon.Verify(strUserName, strPassword);
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
            strLogInName = tbxLogIn.Text;
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
                MessageBox.Show("I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n" + ex.Message,
    "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            frmCreateAcct createAcct = new frmCreateAcct();
            createAcct.ShowDialog();
            this.Hide();
        }
    }
}
