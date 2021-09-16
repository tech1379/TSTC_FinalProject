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
    public partial class frmMain : Form
    {
        int toggle = 0;
        public static string logInName;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                string query2;
                string personType;
                string result;
                string userName = tbxLogIn.Text;
                string password = tbxPassword.Text;
                query = "SELECT COUNT(*) FROM tekelle21fa2332.Logon WHERE LogonName = '" + userName + "' AND Password = '"
                    + password + "';";
                result = clsSQL.DatabaseCommandLogon(query);
                int logon = Int32.Parse(result);
                query2 = "SELECT PersonType FROM tekelle21fa2332.Person p JOIN tekelle21fa2332.Logon l ON "
                    + "p.PersonID = l.PersonID " + "WHERE LogonName = '" + userName + "' AND Password = '" +
                    password + "';";
                personType = clsSQL.DatabaseCommandLogon(query2);

                if (logon == 1)
                {
                    MessageBox.Show(personType, "PersonType", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have been denied!", "Logon Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("I'm sorry an error has occurred in the program. \n\n" +
     "Please inform the Program Developer that the following error occurred: \n\n\n" + ex.Message,
     "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxEye_Click(object sender, EventArgs e)
        {
            if (toggle % 2 == 0)
            {
                tbxPassword.PasswordChar = '\0';
                toggle++;
            }
            else
            {
                tbxPassword.PasswordChar = '*';
                toggle++;
            }
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxLogIn.Text == "")
                {
                    MessageBox.Show("You must enter a username!", "Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string query = "SELECT LogOnName FROM tekelle21fa2332.Logon WHERE LogonName = '" + tbxLogIn.Text + "';";
                logInName = clsSQL.DatabaseCommandLogon(query);
                if (logInName == tbxLogIn.Text)
                {
                    this.Hide();
                    frmPassword password = new frmPassword();
                    password.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username!", "User Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
