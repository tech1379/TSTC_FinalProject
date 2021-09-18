using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    class clsValidation
    {
        public static string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public static bool ValidZip(string strZipCode)
        {
            bool boolValidZipCode = false;
            try
            {
                
                string strUSZip = @"^\d{5}(?:[-\s]\d{4})?$";
                if ((Regex.Match(strZipCode, strUSZip).Success))
                {
                    boolValidZipCode = true;
                }
                else
                {
                    boolValidZipCode = false;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolValidZipCode;
        }

        public static bool ValidPhone(string strPhone)
        {
            bool boolValidPhone = false;
            try
            {
                string strPhonePattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
                if ((Regex.Match(strPhone, strPhonePattern).Success))
                {
                    boolValidPhone = true;
                }
                else
                {
                    boolValidPhone = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolValidPhone;
        }
        public static bool ValidEmail(string strEmailAddress)
        {
            bool boolValidEmail = false;
            try
            {
                string strEmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                if ((Regex.Match(strEmailAddress, strEmailPattern).Success))
                {
                    boolValidEmail = true;
                }
                else
                {
                    boolValidEmail = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolValidEmail;
        }
    }
}
