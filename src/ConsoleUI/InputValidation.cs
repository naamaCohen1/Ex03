using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class InputValidation
    {
        public string CheckName(string i_Name)
        {
            bool isValid = true;

            if(string.IsNullOrEmpty(i_Name))
            {
                isValid = false;
            }

            if(!isValid)
            {
                throw new ArgumentException("Invalid Owner name. Name can't be empty!");
            }

            return i_Name;
        }

        public string CheckLicenseNumber(string i_LicenseNumber, string i_ParametrName)
        {
            bool isValid = true;
            string msg = null;

            if(string.IsNullOrEmpty(i_LicenseNumber))
            {
                isValid = false;
                msg = string.Format("Invalid {0}. {0} can't be empty!", i_ParametrName);
            }
            else if(!isContainsDigitsAndLetters(i_LicenseNumber))
            {
                isValid = false;
                msg = string.Format("Invalid {0} - {1}", i_ParametrName, i_LicenseNumber);
            }

            if(!isValid)
            {
                throw new ArgumentException(msg);
            }

            return i_LicenseNumber;
        }

        public string CheckNumber(string i_Number, string i_ParametrName)
        {
            bool isValid = true;
            string msg = null;

            if(string.IsNullOrEmpty(i_Number))
            {
                isValid = false;
                msg = string.Format("Invalid {0}. {0} can't be empty!", i_ParametrName);
            }
            else if(!isContainsOnlyDigits(i_Number))
            {
                isValid = false;
                msg = string.Format("Invalid {0} - {1}", i_ParametrName, i_Number);
            }

            if(!isValid)
            {
                throw new ArgumentException(msg);
            }

            return i_Number;
        }

        private bool isContainsOnlyDigits(string i_Number)
        {
            bool isValid = true;

            for(int i = 0; i < i_Number.Length; i++)
            {
                if(!char.IsDigit(i_Number[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private bool isContainsDigitsAndLetters(string i_StrToCheck)
        {
            bool isValid = true;

            for(int i = 0; i < i_StrToCheck.Length; i++)
            {
                if(!char.IsLetterOrDigit(i_StrToCheck[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public int CheckIfInt(string i_NumberStr)
        {
            bool isInt;
            int intNum = 0;

            isInt = int.TryParse(i_NumberStr, out intNum);

            if(!isInt)
            {
                throw new FormatException("Invalid Parameter Type. Failed to Parse parametr from string to int");
            }

            return intNum;
        }

        public float CheckIfFloat(string i_NumberStr)
        {
            bool isFloat = false;
            float floatNum = 0;

            isFloat = float.TryParse(i_NumberStr, out floatNum);

            if(!isFloat)
            {
                throw new FormatException("Invalid Parameter Type. Failed to Parse parametr from string to float");
            }

            return floatNum;
        }

        public bool CheckIfBool(string i_BoolStr)
        {
            bool isBool;
            bool boolParam;

            isBool = bool.TryParse(i_BoolStr.ToLower(), out boolParam);

            if(!isBool)
            {
                throw new FormatException("Invalid Parameter Type. Failed to Parse parametr from string to bool");
            }

            return boolParam;
        }
    }
}