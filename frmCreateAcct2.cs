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
        
        string strInsertPerson = frmCreateAcct.strInsert;
        public static bool boolAddManager;
        public static bool boolEditManager;
        public static bool boolEditCustomer;
        public static bool boolAddCustomer;
        public static int intPersonID;
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
                boolAddManager = frmCreateAcct.boolAddManager;
                boolEditManager = frmCreateAcct.boolEditManager;
                boolEditCustomer = frmCreateAcct.boolEditCustomer;
                boolAddCustomer = frmCreateAcct.boolAddCustomer;
                intPersonID = frmCreateAcct.intPersonID;
                hlpMain.HelpNamespace = Application.StartupPath + "\\CreateAcct2.chm";
                LoadQuestions();
                cbxPosition.Visible = false;
                lblPosition.Visible = false;
                if(boolEditManager == true || boolEditCustomer == true)
                {
                    btnCreate.Text = "Save Edits";
                }

                if (boolEditManager == true || boolEditCustomer == true)
                {
                    clsSQL.DatabaseCommandManagersLogin(tbxUserName, tbxPassword, tbxConfirm, tbxFirstAns, tbxSecondAns, tbxThirdAns, intPersonID);
                }
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
                else if (tbxSecondAns.Text == "")
                {
                    MessageBox.Show("Second Answer cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxThirdAns.Text == "")
                {
                    MessageBox.Show("Third Answer cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cbxFirstQ.SelectedIndex == -1)
                {
                    MessageBox.Show("First Question cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cbxSecondQ.SelectedIndex == -1)
                {
                    MessageBox.Show("Second Question cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cbxThirdQ.SelectedIndex == -1)
                {
                    MessageBox.Show("Third Question cannot be empty.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (strPassword != strConfirm)
                {
                    MessageBox.Show("Passwords do not match!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsLogon.LogOnRequirements(strLogOnName))
                {
                    MessageBox.Show("UserName not correct format!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsLogon.PasswordRequirements(strPassword))
                {
                    MessageBox.Show("Password not correct format!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string strLogOnNameQuery = "SELECT COUNT(LogonName) FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogOnName + "';";
                //MessageBox.Show(strLogOnNameQuery);
                string strLogOnCount = clsSQL.DatabaseCommandLogon(strLogOnNameQuery);
                int intLogOnCount = Convert.ToInt32(strLogOnCount);
                if (intLogOnCount > 0 && boolEditManager == false && boolEditCustomer == false)
                {
                    MessageBox.Show("Username already used!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //insert into person then login into db
                clsSQL.UpdateDatabase(strInsertPerson);
                string strPersonIDQuery = "SELECT MAX(PersonID) FROM tekelle21fa2332.Person;";
                string strPersonID = clsSQL.DatabaseCommandLogon(strPersonIDQuery);
                string strInsert = "";
                if (boolAddManager == true)
                {
                   strInsert = "INSERT INTO tekelle21fa2332.Logon VALUES (" + Convert.ToInt32(strPersonID) + ", '" + strLogOnName.ToUpper() + "', '" +
    strPassword + "', '" + cbxFirstQ.SelectedItem + "', '" + strFirstAnswer + "', '" + cbxSecondQ.SelectedItem + "', '" +
    strSecondAnswer + "', '" + cbxThirdQ.SelectedItem + "', '" + strThirdAns + "', 'Manager', NULL, NULL)";
                    clsSQL.UpdateDatabase(strInsert);
                    MessageBox.Show("Account Created Successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Application.OpenForms["frmManager"].Hide();
                    frmManager frmManagerNew = new frmManager();
                    frmManagerNew.ShowDialog();

                }
                else if (boolEditManager == true)
                {
                    strInsert = "UPDATE tekelle21fa2332.Logon SET LogonName = '" + strLogOnName.ToUpper() + "', Password = '" + strPassword + "', FirstChallengeQuestion = '" +
                        cbxFirstQ.SelectedItem + "', FirstChallengeAnswer = '" + strFirstAnswer + "', SecondChallengeQuestion = '" + cbxSecondQ.SelectedItem + "', ThirdChallengeQuestion = '" +
                        cbxThirdQ.SelectedItem + "', PositionTitle = 'Manager' WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strInsert);
                    MessageBox.Show("Account successfully edited.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Application.OpenForms["frmManager"].Hide();
                    frmManager frmManagerNew = new frmManager();
                    frmManagerNew.ShowDialog();
                }
                else if(boolEditCustomer == true)
                {
                    strInsert = "UPDATE tekelle21fa2332.Logon SET LogonName = '" + strLogOnName.ToUpper() + "', Password = '" + strPassword + "', FirstChallengeQuestion = '" +
                        cbxFirstQ.SelectedItem + "', FirstChallengeAnswer = '" + strFirstAnswer + "', SecondChallengeQuestion = '" + cbxSecondQ.SelectedItem + "', ThirdChallengeQuestion = '" +
                        cbxThirdQ.SelectedItem + "', PositionTitle = 'Customer' WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strInsert);
                    MessageBox.Show("Account successfully edited.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Application.OpenForms["frmManager"].Hide();
                    frmManager frmManagerNew = new frmManager();
                    frmManagerNew.ShowDialog();
                }
                else
                {
                    strInsert = "INSERT INTO tekelle21fa2332.Logon VALUES (" + Convert.ToInt32(strPersonID) + ", '" + strLogOnName.ToUpper() + "', '" +
                        strPassword + "', '" + cbxFirstQ.SelectedItem + "', '" + strFirstAnswer + "', '" + cbxSecondQ.SelectedItem + "', '" +
                        strSecondAnswer + "', '" + cbxThirdQ.SelectedItem + "', '" + strThirdAns + "', 'Customer', NULL, NULL)";
                    clsSQL.UpdateDatabase(strInsert);
                    MessageBox.Show("Account Created Successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    if (boolAddCustomer == true)
                    {
                        this.Hide();
                        Application.OpenForms["frmManager"].Hide();
                        frmManager frmManagerNew = new frmManager();
                        frmManagerNew.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        Application.OpenForms["frmLogIn"].Hide();
                        frmLogIn frmLogInNew = new frmLogIn();
                        frmLogInNew.ShowDialog();
                    }

                }
                
               // frmLogIn frmLoginNew = new frmLogIn();
               //frmLoginNew.ShowDialog();
            }
            catch (Exception ex)
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
        public void LoadQuestions()
        {
            for (int i = 22000; i < 22003; i++)
            {
                string strGetSecurityQuestion = "SELECT SecurityQuestion FROM tekelle21fa2332.SecurityQuestions WHERE SecurityQuestionID = " + i + ";";
                string strSecurityQuestion1 = clsSQL.DatabaseCommandLogon(strGetSecurityQuestion);
                cbxFirstQ.Items.Add(strSecurityQuestion1);
            }
            for (int i = 22003; i < 22006; i++)
            {
                string strGetSecurityQuestion = "SELECT SecurityQuestion FROM tekelle21fa2332.SecurityQuestions WHERE SecurityQuestionID = " + i + ";";
                string strSecurityQuestion2 = clsSQL.DatabaseCommandLogon(strGetSecurityQuestion);
                cbxSecondQ.Items.Add(strSecurityQuestion2);
            }
            for (int i = 22006; i < 22009; i++)
            {
                string strGetSecurityQuestion = "SELECT SecurityQuestion FROM tekelle21fa2332.SecurityQuestions WHERE SecurityQuestionID = " + i + ";";
                string strSecurityQuestion3 = clsSQL.DatabaseCommandLogon(strGetSecurityQuestion);
                cbxThirdQ.Items.Add(strSecurityQuestion3);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (boolAddManager == true)
            {
                this.Hide();
                Application.OpenForms["frmManager"].Hide();
                frmManager frmManagerNew = new frmManager();
                frmManagerNew.ShowDialog();
            }
            else
            {
                frmLogIn login = new frmLogIn();
                this.Hide();
                login.ShowDialog();
            }
        }

        private void frmCreateAcct2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (boolAddManager == true || boolEditManager == true || boolEditCustomer == true)
                {
                    this.Hide();
                    Application.OpenForms["frmManager"].Hide();
                    frmManager frmManagerNew = new frmManager();
                    frmManagerNew.ShowDialog();
                }
                else
                {
                    frmLogIn login = new frmLogIn();
                    this.Hide();
                    login.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpMain.HelpNamespace);
        }
    }
}
