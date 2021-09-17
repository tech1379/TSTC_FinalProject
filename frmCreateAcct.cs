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
    public partial class frmCreateAcct : Form
    {
        public frmCreateAcct()
        {
            InitializeComponent();
        }

        private void frmCreateAcct_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //insert a new Person record after validating zip, phone and email
            string strTitle = tbxTitle.Text.Trim();
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
                if (!clsValidation.ValidEmail(strEmail))
                {
                    MessageBox.Show("Email not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidPhone(strPrimPhone))
                {
                    MessageBox.Show("Primary Phone not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidPhone(strSecondPhone))
                {
                    MessageBox.Show("Second Phone not entered Correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string strInsert = "INSERT INTO tekelle21fa2332.Person VALUES ('" + strTitle + "', '" + strFirstName + "', '" + strMiddleName +
                   "', '" + strLastName + "', '" + strSuffix + "', '" + strAddress1 + "', '" + strAddress2 + "', '" + strAddress3 +
                   "', '" + strCity + "', '" + strZipCode + "', '" + strState + "', '" + strEmail + "', '" + strPrimPhone + "', '" +
                   strSecondPhone + "', NULL, NULL, 'Customer');";
                MessageBox.Show(strInsert);
                clsSQL.UpdateDatabase(strInsert);
            }
            catch (Exception ex)
            {
                MessageBox.Show("I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n" + ex.Message,
    "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
