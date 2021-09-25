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

                int intSpecialCharCount = 0;
                for (int i = 0; i < strZipCode.Length; i++)
                {
                    if (strZipCode[i] == '-')
                    {
                        intSpecialCharCount++;
                    }
                }
                if (intSpecialCharCount > 2)
                {
                    boolValidZipCode = false;
                }
                else
                {
                    boolValidZipCode = true;
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
                int intSpecialCharCount = 0;
                int intNumberCount = 0;
                for (int i = 0; i < strPhone.Length; i++)
                {
                    if(strPhone[i] == '-')
                    {
                        intSpecialCharCount++;
                    }
                    else
                    {
                        intNumberCount++;
                    }
                }
                if (intSpecialCharCount > 2)
                {
                    boolValidPhone = false;
                }
                else if(intNumberCount > 10)
                {
                    boolValidPhone = false;
                }
                else
                {
                    boolValidPhone = true;
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
        public static bool ValidCreditCard(string strCreditCard)
        {
            bool boolCreditCard = false;
            try
            {
                string strCreditCardPattern = @"^\d{4}-\d{4}-\d{4}-\d{4}$";
                if ((Regex.Match(strCreditCard, strCreditCardPattern).Success))
                {
                    boolCreditCard = true;
                }
                else
                {
                    boolCreditCard = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolCreditCard;
        }
        public static bool ValidExpiration(string strExpiration)
        {
            bool boolExpiration = false;
            try
            {
                string strExpirationPattern = @"^\d{2}/\d{2}$";
                if ((Regex.Match(strExpiration, strExpirationPattern).Success))
                {
                    boolExpiration = true;
                }
                else
                {
                    boolExpiration = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolExpiration;
        }
    }
}
