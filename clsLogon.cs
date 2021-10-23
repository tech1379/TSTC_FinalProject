using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    class clsLogon
    {
        public static string message = "I'm sorry an error has occurred in the program. \n\n" +
            "Please inform the Program Developer that the following error occurred: \n\n\n";

        public static int Verify(string strUserName, string strPassword, ref string strPersonID)
        {
            //password check routine, verify username and password then get person type
            int intFormControl = 0;
            try
            {
                
                string strQueryLogOnPass;
                string strQueryPersonType;
                string strQueryPersonID;
                string strPersonType;
                string strResult;
                strQueryLogOnPass = "SELECT COUNT(*) FROM tekelle21fa2332.Logon WHERE LogonName = '" + strUserName + "' AND Password = '"
                    + strPassword + "';";
                strResult = clsSQL.DatabaseCommandLogon(strQueryLogOnPass);
                int logon = Int32.Parse(strResult);
                strQueryPersonType = "SELECT PersonType FROM tekelle21fa2332.Person p JOIN tekelle21fa2332.Logon l ON "
                    + "p.PersonID = l.PersonID " + "WHERE LogonName = '" + strUserName + "' AND Password = '" +
                    strPassword + "';";
                strPersonType = clsSQL.DatabaseCommandLogon(strQueryPersonType);
                strQueryPersonID = "SELECT PersonID FROM tekelle21fa2332.Logon WHERE LogonName = '" + strUserName + "' AND Password = '"
                    + strPassword + "';";
                string strQueryAccountDisabled = "SELECT AccountDisabled FROM tekelle21fa2332.Logon WHERE LogonName = '" + strUserName + "';";
                string strAccountDisabled = clsSQL.DatabaseCommandLogon(strQueryAccountDisabled);
                if (strAccountDisabled == "True")
                {
                    MessageBox.Show("Your account has been disabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                
                if (logon == 1)
                {
                    strPersonID = clsSQL.DatabaseCommandLogon(strQueryPersonID);
                    if(strPersonType == "Manager")
                    {
                        intFormControl = 1;
                    }
                    else if (strPersonType == "Employee")
                    {
                        intFormControl = 2;
                    }
                    else if(strPersonType == "Customer")
                    {
                        intFormControl = 3;
                    }
                }
                else
                {
                    MessageBox.Show("You have been denied!", "Logon Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message,"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return intFormControl;
        }

        public static bool Reset(string strUserName)
        {
            bool boolVerify = false;
            //check username verify and send to password reset form
            try
            {
                
                string strQueryLogOnName = "SELECT LogOnName FROM tekelle21fa2332.Logon WHERE LogonName = '" + strUserName + "';";
                string strLogInName = clsSQL.DatabaseCommandLogon(strQueryLogOnName);
                if (strLogInName == strUserName)
                {
                    boolVerify = true;
                }
                else
                {
                   
                    boolVerify = false; ;
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolVerify;
        }

        public static bool PasswordRequirements(string strPassword)
        {
            bool boolPassword = false;
            try
            {

                int intUpperCaseCount = 0;
                int intLowerCaseCount = 0;
                int intNumberCount = 0;
                int intSpaceCount = 0;
                int intSpecialCount = 0;
                for (int i = 0; i < strPassword.Length; i++)
                {
                    if (char.IsUpper(strPassword[i]))
                    {
                        intUpperCaseCount++;
                    }
                    else if (char.IsLower(strPassword[i]))
                    {
                        intLowerCaseCount++;
                    }
                    else if (char.IsDigit(strPassword[i]))
                    {
                        intNumberCount++;
                    }
                    else if (char.IsWhiteSpace(strPassword[i]))
                    {
                        intSpaceCount++;
                    }
                    else
                    {
                        intSpecialCount++;
                    }
                }
                if (strPassword.Length < 8 || strPassword.Length > 20)
                {
                    boolPassword = false;
                }
                else if (intSpaceCount >= 1)
                {
                    boolPassword = false;
                }
                else if (intLowerCaseCount >= 1 && intUpperCaseCount >= 1 && intNumberCount >= 1 && intSpecialCount >= 1)
                {
                    boolPassword = true;
                }
                else if (intUpperCaseCount >= 1 && intLowerCaseCount >= 1 && intNumberCount >= 1)
                {
                    boolPassword = true;
                }
                else if (intLowerCaseCount >= 1 && intNumberCount >= 1 && intSpecialCount >= 1)
                {
                    boolPassword = true;
                }
                else if (intNumberCount >= 1 && intSpecialCount >= 1 && intUpperCaseCount >= 1)
                {
                    boolPassword = true;
                }
                else if (intSpecialCount >= 1 && intUpperCaseCount >= 1 && intLowerCaseCount >= 1)
                {
                    boolPassword = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolPassword;
        }

        public static string GetSecurityQuestion1(string strLogInName)
        {
            //query db to populate the labels security questions
            string strSecurityQuestion1;
            string strSecurityQuery1 = "";
            try
            {
                strSecurityQuestion1 = "SELECT FirstChallengeQuestion FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogInName + "';";
                strSecurityQuery1 = clsSQL.DatabaseCommandLogon(strSecurityQuestion1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strSecurityQuery1;
        }
        public static string GetSecurityQuestion2(string strLogInName)
        {
            //query db to populate the labels security questions
            string strSecurityQuestion2;
            string strSecurityQuery2 = "";
            try
            {
                strSecurityQuestion2 = "SELECT SecondChallengeQuestion FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogInName + "';";
                strSecurityQuery2 = clsSQL.DatabaseCommandLogon(strSecurityQuestion2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message,"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strSecurityQuery2;
        }
        public static string GetSecurityQuestion3(string strLogInName)
        {
            //query db to populate the labels security questions
            string strSecurityQuestion3;
            string strSecurityQuery3 = "";
            try
            {
                strSecurityQuestion3 = "SELECT ThirdChallengeQuestion FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogInName + "';";
                strSecurityQuery3 = clsSQL.DatabaseCommandLogon(strSecurityQuestion3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message,"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strSecurityQuery3;
        }
        public static string GetSecurityAnswer1(string strLogInName)
        {
            //query db to populate the labels security questions
            string strSecurityAnswer1;
            string strSecurityQuery1 = "";
            try
            {
                strSecurityAnswer1 = "SELECT FirstChallengeAnswer FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogInName + "';";
                strSecurityQuery1 = clsSQL.DatabaseCommandLogon(strSecurityAnswer1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strSecurityQuery1;
        }
        public static string GetSecurityAnswer2(string strLogInName)
        {
            //query db to populate the labels security questions
            string strSecurityAnswer2;
            string strSecurityQuery2 = "";
            try
            {
                strSecurityAnswer2 = "SELECT SecondChallengeAnswer FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogInName + "';";
                strSecurityQuery2 = clsSQL.DatabaseCommandLogon(strSecurityAnswer2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strSecurityQuery2;
        }
        public static string GetSecurityAnswer3(string strLogInName)
        {
            //query db to populate the labels security questions
            string strSecurityAnswer3;
            string strSecurityQuery3 = "";
            try
            {
                strSecurityAnswer3 = "SELECT ThirdChallengeAnswer FROM tekelle21fa2332.Logon WHERE LogonName = '" + strLogInName + "';";
                strSecurityQuery3 = clsSQL.DatabaseCommandLogon(strSecurityAnswer3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message,"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strSecurityQuery3;
        }
        public static bool LogOnRequirements(string strUserName)
        {
            bool boolLogInName = false;
            try
            {
                int intSpecialCount = 0;
                for (int i = 0; i < strUserName.Length; i++)
                {
                    if (!char.IsLetterOrDigit(strUserName[i]))
                    {
                        intSpecialCount++;
                    }
                }
                if (char.IsDigit(strUserName[0]))
                {
                    boolLogInName = false;
                }
                else if(char.IsWhiteSpace(strUserName[0]))
                {
                    boolLogInName = false;
                }
                else if(intSpecialCount > 0)
                {
                    boolLogInName = false;
                }
                else if(strUserName.Length < 8 || strUserName.Length > 20)
                {
                    boolLogInName = false;
                }
                else
                {
                    boolLogInName = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolLogInName;
        }
    }
}
