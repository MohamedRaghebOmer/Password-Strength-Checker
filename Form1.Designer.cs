namespace PasswordStrengthChecker
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLowerCase = new System.Windows.Forms.Label();
            this.lblUperCase = new System.Windows.Forms.Label();
            this.lblNumbers = new System.Windows.Forms.Label();
            this.lblSymbols = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOverlay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(588, 379);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(528, 45);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.DoubleClick += new System.EventHandler(this.txtPassword_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(297, 615);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(848, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tip: Avoid the use of dictionary words or common names,";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(412, 659);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(619, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "and avoid using any personal information.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1154, 91);
            this.label3.TabIndex = 3;
            this.label3.Text = "How Secure is Your Password?";
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.cbShowPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbShowPassword.Location = new System.Drawing.Point(265, 290);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(257, 43);
            this.cbShowPassword.TabIndex = 4;
            this.cbShowPassword.Text = "Show Password";
            this.cbShowPassword.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(678, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(430, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Time to crack your password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(797, 516);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "0 Seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(583, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "0 Character Containing:";
            // 
            // lblLowerCase
            // 
            this.lblLowerCase.AutoSize = true;
            this.lblLowerCase.BackColor = System.Drawing.Color.Transparent;
            this.lblLowerCase.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerCase.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblLowerCase.Location = new System.Drawing.Point(783, 430);
            this.lblLowerCase.Name = "lblLowerCase";
            this.lblLowerCase.Size = new System.Drawing.Size(103, 24);
            this.lblLowerCase.TabIndex = 8;
            this.lblLowerCase.Text = "Lower case";
            // 
            // lblUperCase
            // 
            this.lblUperCase.AutoSize = true;
            this.lblUperCase.BackColor = System.Drawing.Color.Transparent;
            this.lblUperCase.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUperCase.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblUperCase.Location = new System.Drawing.Point(874, 430);
            this.lblUperCase.Name = "lblUperCase";
            this.lblUperCase.Size = new System.Drawing.Size(106, 24);
            this.lblUperCase.TabIndex = 9;
            this.lblUperCase.Text = "Upper case";
            // 
            // lblNumbers
            // 
            this.lblNumbers.AutoSize = true;
            this.lblNumbers.BackColor = System.Drawing.Color.Transparent;
            this.lblNumbers.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumbers.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblNumbers.Location = new System.Drawing.Point(969, 430);
            this.lblNumbers.Name = "lblNumbers";
            this.lblNumbers.Size = new System.Drawing.Size(90, 24);
            this.lblNumbers.TabIndex = 10;
            this.lblNumbers.Text = "Numbers";
            // 
            // lblSymbols
            // 
            this.lblSymbols.AutoSize = true;
            this.lblSymbols.BackColor = System.Drawing.Color.Transparent;
            this.lblSymbols.Font = new System.Drawing.Font("Microsoft YaHei", 11F);
            this.lblSymbols.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblSymbols.Location = new System.Drawing.Point(1047, 430);
            this.lblSymbols.Name = "lblSymbols";
            this.lblSymbols.Size = new System.Drawing.Size(89, 25);
            this.lblSymbols.TabIndex = 11;
            this.lblSymbols.Text = "Symbols";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(366, 755);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(672, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Your passwords are never stored. Even if they were, we have no idea who you are!";
            // 
            // lblOverlay
            // 
            this.lblOverlay.AutoSize = true;
            this.lblOverlay.BackColor = System.Drawing.Color.White;
            this.lblOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.9F);
            this.lblOverlay.ForeColor = System.Drawing.Color.Gray;
            this.lblOverlay.Location = new System.Drawing.Point(590, 382);
            this.lblOverlay.Name = "lblOverlay";
            this.lblOverlay.Size = new System.Drawing.Size(243, 37);
            this.lblOverlay.TabIndex = 13;
            this.lblOverlay.Text = "Enter Password";
            this.lblOverlay.Click += new System.EventHandler(this.lblOverlay_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(710, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(321, 60);
            this.label8.TabIndex = 14;
            this.label8.Text = "No Password";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PasswordStrengthChecker.Properties.Resources.BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1347, 806);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOverlay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblSymbols);
            this.Controls.Add(this.lblNumbers);
            this.Controls.Add(this.lblUperCase);
            this.Controls.Add(this.lblLowerCase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbShowPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmMainForm";
            this.Text = "Make a Strong Password";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLowerCase;
        private System.Windows.Forms.Label lblUperCase;
        private System.Windows.Forms.Label lblNumbers;
        private System.Windows.Forms.Label lblSymbols;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOverlay;
        private System.Windows.Forms.Label label8;
    }
}

