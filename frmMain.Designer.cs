
namespace FA21_Final_Project
{
    partial class frmMain
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
            this.gbxLogIn = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblForgot = new System.Windows.Forms.Label();
            this.pbxEye = new System.Windows.Forms.PictureBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxLogIn = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.gbxLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEye)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxLogIn
            // 
            this.gbxLogIn.Controls.Add(this.btnLogin);
            this.gbxLogIn.Controls.Add(this.lblForgot);
            this.gbxLogIn.Controls.Add(this.pbxEye);
            this.gbxLogIn.Controls.Add(this.tbxPassword);
            this.gbxLogIn.Controls.Add(this.tbxLogIn);
            this.gbxLogIn.Controls.Add(this.lblPassword);
            this.gbxLogIn.Controls.Add(this.lblLogIn);
            this.gbxLogIn.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLogIn.Location = new System.Drawing.Point(126, 64);
            this.gbxLogIn.Name = "gbxLogIn";
            this.gbxLogIn.Size = new System.Drawing.Size(436, 243);
            this.gbxLogIn.TabIndex = 0;
            this.gbxLogIn.TabStop = false;
            this.gbxLogIn.Text = "Tek\'s Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(289, 194);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 38);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblForgot
            // 
            this.lblForgot.AutoSize = true;
            this.lblForgot.Location = new System.Drawing.Point(9, 203);
            this.lblForgot.Name = "lblForgot";
            this.lblForgot.Size = new System.Drawing.Size(185, 21);
            this.lblForgot.TabIndex = 5;
            this.lblForgot.Text = "&Forgot Password?";
            this.lblForgot.Click += new System.EventHandler(this.lblForgot_Click);
            // 
            // pbxEye
            // 
            this.pbxEye.Image = global::FA21_Final_Project.Properties.Resources.eye;
            this.pbxEye.Location = new System.Drawing.Point(330, 120);
            this.pbxEye.Name = "pbxEye";
            this.pbxEye.Size = new System.Drawing.Size(64, 30);
            this.pbxEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEye.TabIndex = 4;
            this.pbxEye.TabStop = false;
            this.pbxEye.Click += new System.EventHandler(this.pbxEye_Click);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(13, 120);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(270, 29);
            this.tbxPassword.TabIndex = 3;
            // 
            // tbxLogIn
            // 
            this.tbxLogIn.Location = new System.Drawing.Point(13, 64);
            this.tbxLogIn.Name = "tbxLogIn";
            this.tbxLogIn.Size = new System.Drawing.Size(270, 29);
            this.tbxLogIn.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 96);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(113, 21);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.Location = new System.Drawing.Point(9, 40);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(121, 21);
            this.lblLogIn.TabIndex = 0;
            this.lblLogIn.Text = "Username:";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebsite.Location = new System.Drawing.Point(499, 367);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(145, 21);
            this.lblWebsite.TabIndex = 1;
            this.lblWebsite.Text = "&Tek\'s Website";
            this.lblWebsite.Click += new System.EventHandler(this.lblWebsite_Click);
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(23, 367);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(185, 21);
            this.lblInventory.TabIndex = 2;
            this.lblInventory.Text = "&Browse Inventory";
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.Location = new System.Drawing.Point(475, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(211, 21);
            this.lblCreate.TabIndex = 3;
            this.lblCreate.Text = "&Create New Account";
            this.lblCreate.Click += new System.EventHandler(this.lblCreate_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.Location = new System.Drawing.Point(12, 19);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(122, 21);
            this.lblHelp.TabIndex = 4;
            this.lblHelp.Text = "Need &Help?";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(698, 407);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblWebsite);
            this.Controls.Add(this.gbxLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tek\'s Kennels & Outfitting Login";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxLogIn.ResumeLayout(false);
            this.gbxLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLogIn;
        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbxLogIn;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.PictureBox pbxEye;
        private System.Windows.Forms.Label lblForgot;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblHelp;
    }
}