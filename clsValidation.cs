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
            bool boolZipCode = false;
            try
            {
                string strZipCodePattern = @"^\d{5}-\d{4}$";
                string strZipCodePattern2 = @"^\d{5}$";
                if ((Regex.Match(strZipCode, strZipCodePattern).Success) || (Regex.Match(strZipCode, strZipCodePattern2).Success))
                {
                    boolZipCode = true;
                }
                else
                {
                    boolZipCode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolZipCode;
        }

        public static bool ValidPhone(string strPhone)
        {
            bool boolValidPhone = false;
            try
            {
                string strPhonePattern = @"^\d{3}-\d{3}-\d{4}$";
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
        public static bool ValidPosNegInteger(string strExpiration)
        {
            bool boolValidInteger = false;
            try
            {
                string strExpirationPattern = @"^\-?[1-9]\d{0,8}$";
                if ((Regex.Match(strExpiration, strExpirationPattern).Success))
                {
                    boolValidInteger = true;
                }
                else
                {
                    boolValidInteger = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolValidInteger;
        }
        public static bool ValidDecimal(string strDecimal)
        {
            bool boolValidDecimal = false;
            try
            {
                string strDecimalPattern = @"^-?[0-9]*\.?[0-9]+$";
                if ((Regex.Match(strDecimal, strDecimalPattern).Success))
                {
                    boolValidDecimal = true;
                }
                else
                {
                    boolValidDecimal = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolValidDecimal;
        }
    }
}
