using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
