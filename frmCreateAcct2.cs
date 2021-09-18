//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my create login form
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
    public partial class frmCreateAcct2 : Form
    {
        string strPersonID = frmCreateAcct.strPersonID;
        int intToggle1 = 0;
        int intToggle2 = 0;
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
            "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmCreateAcct2()
        {
            InitializeComponent();
        }

        private void frmCreateAcct2_Load(object sender, EventArgs e)
        {
            try
            {
                //load combo boxes
                string[] strQuestionArray = new string[6];
                strQuestionArray[0] = "Who is your favorite author?";
                strQuestionArray[1] = "What is your favorite food?";
                strQuestionArray[2] = "What is your favorite movie?";
                strQuestionArray[3] = "What is your favorite band?";
                strQuestionArray[4] = "What is your favorite color?";
                strQuestionArray[5] = "Who is your favorite singer?";

                for (int i = 0; i < strQuestionArray.Length; i++)
                {
                    cbxFirstQ.Items.Add(strQuestionArray[i]);
                    cbxSecondQ.Items.Add(strQuestionArray[i]);
                    cbxThirdQ.Items.Add(strQuestionArray[i]);
                }

                //cbxPosition.Items.Add("Manager");
                //cbxPosition.Items.Add("Employee");
                cbxPosition.Items.Add("Customer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //insert a new Login record after validating username and password
            string strLogOnName = tbxUserName.Text.Trim();
            string strPassword = tbxPassword.Text.Trim();
            string strConfirm = tbxConfirm.Text.Trim();
            string strFirstAnswer = tbxFirstAns.Text.Trim();
            string strSecondAnswer = tbxSecondAns.Text.Trim();
            string strThirdAns = tbxThirdAns.Text.Trim();

            try
            {
                if (tbxUserName.Text == "")
                {
                    MessageBox.Show("UserName cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxPassword.Text == "")
                {
                    MessageBox.Show("Password cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxConfirm.Text == "")
                {
                    MessageBox.Show("Confirm Password cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxFirstAns.Text == "")
                {
                    MessageBox.Show("First Answer cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(tbxSecondAns.Text == "")
                {
                    MessageBox.Show("Second Answer cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxThirdAns.Text == "")
                {
                    MessageBox.Show("Third Answer cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(cbxFirstQ.SelectedIndex == -1)
                {
                    MessageBox.Show("First Question cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(cbxSecondQ.SelectedIndex == -1)
                {
                    MessageBox.Show("Second Question cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(cbxThirdQ.SelectedIndex == -1)
                {
                    MessageBox.Show("Third Question cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(cbxPosition.SelectedIndex == -1)
                {
                    MessageBox.Show("Position Title cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (strPassword != strConfirm)
                {
                    MessageBox.Show("Passwords do not match!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsLogon.PasswordRequirements(strPassword))
                {
                    MessageBox.Show("Password not correct format!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsLogon.LogOnRequirements(strLogOnName))
                {
                    MessageBox.Show("LogInName not correct format!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strLogOnNameQuery = "SELECT COUNT(LogonName) FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogOnName + "';";
                MessageBox.Show(strLogOnNameQuery);
                string strLogOnCount = clsSQL.DatabaseCommandLogon(strLogOnNameQuery);
                int intLogOnCount = Convert.ToInt32(strLogOnCount);
                if(intLogOnCount > 0)
                {
                    MessageBox.Show("Username already used!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //insert into db
                string strInsert = "INSERT INTO tekelle21fa2332.Logon VALUES (" + Convert.ToInt32(strPersonID) + ", '" + strLogOnName.ToUpper() + "', '" +
                    strPassword + "', '" + cbxFirstQ.SelectedItem + "', '" + strFirstAnswer + "', '" + cbxSecondQ.SelectedItem + "', '" +
                    strSecondAnswer + "', '" + cbxThirdQ.SelectedItem + "', '" + strThirdAns + "', 'Customer', NULL, NULL)";
                MessageBox.Show(strInsert);
                clsSQL.UpdateDatabase(strInsert);
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxPass_Click(object sender, EventArgs e)
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

        private void pbxConfirm_Click(object sender, EventArgs e)
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
    }
}
