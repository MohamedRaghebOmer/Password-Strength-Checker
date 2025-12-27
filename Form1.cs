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

        bool HasCharacterAppearedMoreThanThreeTimes(string password)
        {
            int[] freq = new int[256];

            foreach (char c in password)
            {
                freq[c]++;
                if (freq[c] > 3)
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
            3- All password is the same char type
            4- if the same char appeard more than 3 times
            */


            // if one condition is true, then the password IsVeryWeek
            return Password.Length < 5 || IsCommonPassword(Password)
                || HasCharacterAppearedMoreThanThreeTimes(Password)
                || IsTheSameCharType(Password);
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
             */

            return (Password.Length == 5 && !IsVeryWeak(Password) ||
                (Password.Length == 6 && CountCharacterTypes
                (Password) == 2));
        }

        // new
        bool IsMedium(string Password)
        {
            /*
                               (Medium password conditions)
             1. password.length = 6 || Password.length = 7
             2. if (Password.length = 8) && has 3 or 2 characters types       
             */

            if (string.IsNullOrEmpty(Password))
                return false;

            int types = CountCharacterTypes(Password);

            return
                (!IsWeak(Password) && (Password.Length == 6 || Password.Length == 7)) ||
                (Password.Length == 8 && (types == 2 || types == 3));
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = true;
            lblOverlay.BringToFront();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            lblOverlay.Visible = false;
            txtPassword.Focus();
            txtPassword.ReadOnly = false;
            txtPassword.PasswordChar = '•';
            txtPassword.ForeColor = Color.Black;
        }

        private void txtPassword_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblOverlay_Click(object sender, EventArgs e)
        {
            lblOverlay.Visible = false;
            txtPassword.ReadOnly = false;
            txtPassword.Focus();
            txtPassword.Text = "";
            txtPassword.PasswordChar = '•';
            txtPassword.ForeColor = Color.Black;
        }
    }
}
