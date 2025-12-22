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

        static bool HasCharacterAppearedMoreThanThreeTimes(string password)
        {
            foreach (char c in password)
            {
                int count = 0;
                foreach (char x in password)
                {
                    if (x == c)
                        count++;
                }

                if (count > 3)
                    return true;
            }

            return false;
        }

        // next step is implement bool IsVeryWeek() {...}

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
