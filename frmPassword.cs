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
        string logInName = frmMain.logInName;
        public frmPassword()
        {
            InitializeComponent();
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT FirstChallengeQuestion FROM tekelle21fa2332.Logon WHERE LogonName = '" + logInName + "';";
                string query2 = "SELECT SecondChallengeQuestion FROM tekelle21fa2332.Logon WHERE LogonName = '" + logInName + "';";
                string query3 = "SELECT ThirdChallengeQuestion FROM tekelle21fa2332.Logon WHERE LogonName = '" + logInName + "';";
                string answer1 = clsSQL.DatabaseCommandLogon(query);
                string answer2 = clsSQL.DatabaseCommandLogon(query2);
                string answer3 = clsSQL.DatabaseCommandLogon(query3);
                lblSC1.Text = answer1;
                lblSC2.Text = answer2;
                lblSC3.Text = answer3;
            }
            catch(Exception ex)
            {
                MessageBox.Show("I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n" + ex.Message,
    "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
