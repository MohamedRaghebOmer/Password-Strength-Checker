using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PasswordStrengthChecker
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        bool IsCommonPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return true;

            string[] CommonWords =
            {
            // Basic common passwords
            "password", "pass", "passwd", "admin", "administrator",
            "root", "user", "login", "welcome", "guest", "default",

            // Numeric & simple patterns
            "123", "1234", "12345", "123456", "1234567", "12345678",
            "123456789", "0000", "1111", "2222", "3333", "4444",
            "5555", "6666", "7777", "8888", "9999",
            "000000", "111111", "123123", "121212",

            // Keyboard patterns
            "qwerty", "qwertyuiop", "asdf", "asdfgh", "asdf123",
            "zxcv", "zxcvbn", "qaz", "wsx", "edc", "1q2w3e",
            "1qaz2wsx",

            // Common English words
            "love", "iloveyou", "hello", "welcome", "football",
            "monkey", "dragon", "sunshine", "shadow", "master",

            // Names (very common in your region)
            "mohamed", "mohammad", "muhamed", "muhammed",
            "ahmed", "ali", "omar", "youssef", "mostafa",
            "ibrahim", "mahmoud", "abdallah", "abdelrahman",
            "khaled", "hassan", "hussein", "saeed",

            // Dates & years
            "1980", "1985", "1990", "1995", "1998",
            "2000", "2001", "2002", "2005", "2010",
            "2015", "2020", "2021", "2022", "2023",
            "2024", "2025",

            // Mixed but still weak
            "password1", "password123", "password2024",
            "admin123", "admin2024",
            "welcome123", "welcome2024",
            "qwerty123", "abc123", "test123", "user123",
            "login123"
        };

            string lower = password.ToLower();
            foreach (string w in CommonWords)
            {
                if (lower.Contains(w))
                    return true;
            }

            return false;
        }

        bool IsTheSameCharType(string Password)
        {
            if (string.IsNullOrEmpty(Password))
                return true;

            // Check is all the password is digits
            if (char.IsDigit(Password[0]))
            {
                for (int i = 0; i < Password.Length; i++)
                {
                    if (!char.IsDigit(Password[i]))
                        return false;
                }
                return true; // all passwor is digits
            }

            // Is letter (upper or lower)
            if (char.IsUpper(Password[0]) || char.IsLower(Password[0]))
            {
                for (int i = 0; i < Password.Length; i++)
                {
                    if (!char.IsUpper(Password[i]) && !char.IsLower(Password[i]))
                        return false;
                }
                return true; // all password is letters
            }

            // check all password is symbols
            if (!char.IsLetterOrDigit(Password[0]))
            {
                for (int i = 0; i < Password.Length; i++)
                {
                    if (char.IsLetterOrDigit(Password[i]))
                        return false; // there is a char is not symbol
                }

                return true; // all char is symbols
            }

            // It's impossible to continue to here because
            // there is only 4 Probabilities to the char type

            return false;
        }

        bool IsVeryWeak(string Password)
        {
            /* 
                    (Very week password conditions)
            1- Less than 5 characters
            2- Common words even longer than 5 characters
            3- All password is the same char type && length < 5
            */


            // if one condition is true, then the password IsVeryWeek
            return Password.Length < 5 || IsCommonPassword(Password)
                || (IsTheSameCharType(Password) && Password.Length < 5);
        }

        byte CountTrueVar(bool b1, bool b2, bool b3, bool b4)
        {
            byte count = 0;

            if (b1)
                count++;

            if (b2)
                count++;

            if (b3)
                count++;

            if (b4)
                count++;

            return count;
        }

        byte CountCharacterTypes(string Password)
        {
            if (string.IsNullOrEmpty(Password))
                return 0;

            int Counter = 0;
            bool LowerCase = false, UpperCase = false, Digit = false,
            Symbol = false;

            while (Counter < Password.Length)
            {
                if (LowerCase && UpperCase && Digit && Symbol)
                    break;

                if (char.IsLower(Password[Counter]))
                    LowerCase = true;
                else if (char.IsUpper(Password[Counter]))
                    UpperCase = true;
                else if (char.IsDigit(Password[Counter]))
                    Digit = true;
                else
                    Symbol = true;

                Counter++;
            }

            return CountTrueVar(LowerCase, UpperCase, Digit, Symbol);
        }
        
        bool IsWeak(string Password)
        {
            /*
                            (Weak Password conditions)
            - password.length = 5.
            - password.length = 6 and two characters type.
            - All password is the same char type and length < 7
             */

            return (Password.Length == 5 && !IsVeryWeak(Password) ||
                (Password.Length == 6 && CountCharacterTypes(Password) == 2)) ||
                (IsTheSameCharType(Password) && Password.Length < 7);
        }

        bool IsMedium(string Password)
        {
            /*
                               (Medium password conditions)
             1. password.length = 6 || Password.length = 7
             2. if (Password.length = 8) && has 3 or 2 characters types       
             3. All password is the same char type and length < 10
             */

            if (string.IsNullOrEmpty(Password))
                return false;

            byte types = CountCharacterTypes(Password);

            return
                (!IsWeak(Password) && (Password.Length == 6 || Password.Length == 7)) ||
                (Password.Length == 8 && (types == 2 || types == 3)) ||
                (IsTheSameCharType(Password) && Password.Length < 10);
        }

        bool IsStrong(string Password)
        {
            /*
                (Strong Password Conditions)

                - length 8 or 9 and has 4 character types
                - length 10 and has 3 character types
                - All password has the same char type and length < 13
            */

            if (string.IsNullOrEmpty(Password))
                return false;

            byte types = CountCharacterTypes(Password);

            return
                ((Password.Length == 8 || Password.Length == 9) && types == 4) ||
                (Password.Length == 10 && types == 3) ||
                (IsTheSameCharType(Password) && Password.Length < 13);
        }

        bool IsVeryStrong(string Password)
        {
            /*
                Very Strong Password Conditions
                - length 10–13 and has 4 character types
                - length 14 or more and has at least 3 character types
                - All passwor has the same char type and length < 17
            */

            if (string.IsNullOrEmpty(Password))
                return false;

            byte types = CountCharacterTypes(Password);

            return
                (Password.Length >= 14 && types >= 3) ||
                (Password.Length >= 10 && Password.Length <= 13 && types == 4) ||
                (IsTheSameCharType(Password) && Password.Length < 17);
        }

        enum enPasswordStrength { eVeryWeak, eWeak, eMedium, eStrong, eVeryStrong };
        enPasswordStrength GetPasswordStrength(string Password)
        {
            if (IsVeryWeak(Password))
                return enPasswordStrength.eVeryWeak;
            else if (IsWeak(Password))
                return enPasswordStrength.eWeak;
            else if (IsMedium(Password))
                return enPasswordStrength.eMedium;
            else if (IsStrong(Password))
                return enPasswordStrength.eStrong;
            else
                return enPasswordStrength.eVeryStrong;
        }

        bool ContainLowerCase(string Password)
        {
            foreach(char c in Password)
            {
                if (char.IsLower(c))
                    return true;
            }
            return false;
        }

        bool ContainUpperCase(string Password)
        {
            foreach(char c in Password)
            {
                if (char.IsUpper(c))
                    return true;
            }
            return false;
        }

        bool ContainNumber(string Password)
        {
            foreach(char c in Password)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        bool ContainSymbol(string Passsword)
        {
            foreach(char c in Passsword)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = true;
            lblOverlay.BringToFront();
        }

        void UpdateTextboxPasswordBackColor()
        {
            switch (GetPasswordStrength(txtPassword.Text.ToString()))
            {
                case enPasswordStrength.eVeryWeak:
                    {
                        txtPassword.BackColor = Color.Red;
                        lblStrength.Text = "Very Weak";
                        break;
                    }
                case enPasswordStrength.eWeak:
                    {
                        txtPassword.BackColor = Color.Orange;
                        lblStrength.Text = "Weak";
                        break;
                    }
                case enPasswordStrength.eMedium:
                    {
                        txtPassword.BackColor = Color.Yellow;
                        lblStrength.Text = "Medium";
                        break;
                    }
                case enPasswordStrength.eStrong:
                    {
                        txtPassword.BackColor = Color.LightGreen;
                        lblStrength.Text = "Strong";
                        break;
                    }
                case enPasswordStrength.eVeryStrong:
                    {
                        txtPassword.BackColor = Color.Green;
                        lblStrength.Text = "Very Strong";
                        break;
                    }
            }

        }
        
        void UpdateLableStrength()
        {
            switch (GetPasswordStrength(txtPassword.Text.ToString()))
            {
                case enPasswordStrength.eVeryWeak:
                    {
                        lblStrength.Text = "Very Weak";
                        lblStrength.ForeColor = Color.Red;
                        break;
                    }
                case enPasswordStrength.eWeak:
                    {
                        lblStrength.Text = "Weak";
                        lblStrength.ForeColor = Color.OrangeRed;
                        break;
                    }
                case enPasswordStrength.eMedium:
                    {
                        lblStrength.Text = "Medium";
                        lblStrength.ForeColor = Color.Goldenrod;
                        break;
                    }
                case enPasswordStrength.eStrong:
                    {
                        lblStrength.Text = "Strong";
                        lblStrength.ForeColor = Color.ForestGreen;
                        break;
                    }
                case enPasswordStrength.eVeryStrong:
                    {
                        lblStrength.Text = "Very Strong";
                        lblStrength.ForeColor = Color.DarkGreen;
                        break;
                    }
            }
        }

        void UpdateLabelCharacterContanning()
        {
            string text = txtPassword.Text.ToString();
            lblCharContaining.Text = text.Length + " Character Containing:";

            // Lowercase
            if (ContainLowerCase(text))
                lblLowerCase.ForeColor = Color.LightGreen;
            else
                lblLowerCase.ForeColor = Color.Gray;

            // Uppercase
            if (ContainUpperCase(text))
                lblUperCase.ForeColor = Color.LightGreen;
            else
                lblUperCase.ForeColor = Color.Gray;

            // Numbers
            if (ContainNumber(text))
                lblNumbers.ForeColor = Color.LightGreen;
            else
                lblNumbers.ForeColor = Color.Gray;
            
            // Symbols
            if (ContainSymbol(text))
                lblSymbols.ForeColor = Color.LightGreen;
            else
                lblSymbols.ForeColor = Color.Gray;
        }

        double CalculateNumberOfPossibleSymbols(string password)
        {
            double counter = 0;

            if (ContainNumber(password))
                counter += 10;   // 0–9

            if (ContainSymbol(password))
                counter += 32;   // common symbols

            if (ContainUpperCase(password))
                counter += 26;

            if (ContainLowerCase(password))
                counter += 26;

            return counter;
        }

        double CalculateTimeToCrackPassword(string password)
        {
            double symbols = CalculateNumberOfPossibleSymbols(password);

            if (symbols == 0 || password.Length == 0)
                return 0;

            double attempts = Math.Pow(symbols, password.Length);

            double attemptsPerSecond = 1_000_000_000; // 1 billion attempts/sec

            return attempts / attemptsPerSecond; // seconds
        }

        string GetTimeLabelFormate(double seconds)
        {
            if (seconds < 1)
                return "Less than a second";

            if (seconds < 60)
                return $"{seconds:F2} seconds";

            double minutes = seconds / 60;
            if (minutes < 60)
                return $"{minutes:F2} minutes";

            double hours = minutes / 60;
            if (hours < 24)
                return $"{hours:F2} hours";

            double days = hours / 24;
            if (days < 365)
                return $"{days:F2} days";

            double years = days / 365;
            if (years < 100)
                return $"{years:F2} years";

            double centuries = years / 100;
            if (centuries < 10_000) // أقل من عشرة آلاف قرن
                return $"{centuries:F2} centuries";

            double millennia = years / 1000;
            return $"{millennia:E2} millennia"; // صيغة علمية للأرقام الكبيرة جدًا
        }

        void UpdatelabelTimeToCrack()
        {
            string password = txtPassword.Text;

            double timeInSeconds = CalculateTimeToCrackPassword(password);
            lblTimeToCrack.Text = GetTimeLabelFormate(timeInSeconds);

            // change forColor due to time
            switch (GetPasswordStrength(password))
            {
                case enPasswordStrength.eVeryWeak:
                    lblTimeToCrack.ForeColor = Color.Red;
                    break;

                case enPasswordStrength.eWeak:
                    lblTimeToCrack.ForeColor = Color.OrangeRed;
                    break;

                case enPasswordStrength.eMedium:
                    lblTimeToCrack.ForeColor = Color.Goldenrod;
                    break;

                case enPasswordStrength.eStrong:
                    lblTimeToCrack.ForeColor = Color.ForestGreen;
                    break;

                case enPasswordStrength.eVeryStrong:
                    lblTimeToCrack.ForeColor = Color.DarkGreen;
                    break;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateTextboxPasswordBackColor();
            UpdateLableStrength();
            UpdateLabelCharacterContanning();
            UpdatelabelTimeToCrack();

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            lblOverlay.Visible = false;
            txtPassword.ReadOnly = false;
        }

        private void lblOverlay_Click(object sender, EventArgs e)
        {
            lblOverlay.Visible = false;
            txtPassword.ReadOnly = false;
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '•';
        }


    }
}
