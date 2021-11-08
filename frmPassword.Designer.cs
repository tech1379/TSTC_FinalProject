
namespace FA21_Final_Project
{
    partial class frmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPassword));
            this.lblNew = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxConfirm = new System.Windows.Forms.TextBox();
            this.lblSecurity1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSC1 = new System.Windows.Forms.Label();
            this.lblAn1 = new System.Windows.Forms.Label();
            this.tbxAn1 = new System.Windows.Forms.TextBox();
            this.lblSecurity2 = new System.Windows.Forms.Label();
            this.lblSC2 = new System.Windows.Forms.Label();
            this.lblAn2 = new System.Windows.Forms.Label();
            this.tbxAn2 = new System.Windows.Forms.TextBox();
            this.lblSecurity3 = new System.Windows.Forms.Label();
            this.lblSC3 = new System.Windows.Forms.Label();
            this.lblAn3 = new System.Windows.Forms.Label();
            this.tbxAn3 = new System.Windows.Forms.TextBox();
            this.pbxPass1 = new System.Windows.Forms.PictureBox();
            this.pbxPass2 = new System.Windows.Forms.PictureBox();
            this.hlpMain = new System.Windows.Forms.HelpProvider();
            this.lblHelp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPass1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPass2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNew.Location = new System.Drawing.Point(51, 24);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(151, 22);
            this.lblNew.TabIndex = 10;
            this.lblNew.Text = "New Password:";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(19, 82);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(183, 22);
            this.lblConfirm.TabIndex = 11;
            this.lblConfirm.Text = "Confirm Password:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(240, 24);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(230, 29);
            this.tbxPassword.TabIndex = 0;
            // 
            // tbxConfirm
            // 
            this.tbxConfirm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConfirm.Location = new System.Drawing.Point(240, 82);
            this.tbxConfirm.Name = "tbxConfirm";
            this.tbxConfirm.PasswordChar = '*';
            this.tbxConfirm.Size = new System.Drawing.Size(230, 29);
            this.tbxConfirm.TabIndex = 1;
            // 
            // lblSecurity1
            // 
            this.lblSecurity1.AutoSize = true;
            this.lblSecurity1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity1.Location = new System.Drawing.Point(8, 147);
            this.lblSecurity1.Name = "lblSecurity1";
            this.lblSecurity1.Size = new System.Drawing.Size(194, 22);
            this.lblSecurity1.TabIndex = 12;
            this.lblSecurity1.Text = "Security Question 1:";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(195, 503);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(119, 63);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset Password";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(403, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 63);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSC1
            // 
            this.lblSC1.BackColor = System.Drawing.Color.White;
            this.lblSC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSC1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC1.Location = new System.Drawing.Point(240, 146);
            this.lblSC1.Name = "lblSC1";
            this.lblSC1.Size = new System.Drawing.Size(465, 29);
            this.lblSC1.TabIndex = 2;
            // 
            // lblAn1
            // 
            this.lblAn1.AutoSize = true;
            this.lblAn1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAn1.Location = new System.Drawing.Point(20, 194);
            this.lblAn1.Name = "lblAn1";
            this.lblAn1.Size = new System.Drawing.Size(182, 22);
            this.lblAn1.TabIndex = 13;
            this.lblAn1.Text = "Security Answer 1:";
            // 
            // tbxAn1
            // 
            this.tbxAn1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAn1.Location = new System.Drawing.Point(240, 191);
            this.tbxAn1.MaxLength = 20;
            this.tbxAn1.Name = "tbxAn1";
            this.tbxAn1.Size = new System.Drawing.Size(465, 29);
            this.tbxAn1.TabIndex = 3;
            // 
            // lblSecurity2
            // 
            this.lblSecurity2.AutoSize = true;
            this.lblSecurity2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity2.Location = new System.Drawing.Point(8, 250);
            this.lblSecurity2.Name = "lblSecurity2";
            this.lblSecurity2.Size = new System.Drawing.Size(194, 22);
            this.lblSecurity2.TabIndex = 14;
            this.lblSecurity2.Text = "Security Question 2:";
            // 
            // lblSC2
            // 
            this.lblSC2.BackColor = System.Drawing.Color.White;
            this.lblSC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSC2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC2.Location = new System.Drawing.Point(240, 249);
            this.lblSC2.Name = "lblSC2";
            this.lblSC2.Size = new System.Drawing.Size(465, 29);
            this.lblSC2.TabIndex = 4;
            // 
            // lblAn2
            // 
            this.lblAn2.AutoSize = true;
            this.lblAn2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAn2.Location = new System.Drawing.Point(20, 309);
            this.lblAn2.Name = "lblAn2";
            this.lblAn2.Size = new System.Drawing.Size(182, 22);
            this.lblAn2.TabIndex = 15;
            this.lblAn2.Text = "Security Answer 2:";
            // 
            // tbxAn2
            // 
            this.tbxAn2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAn2.Location = new System.Drawing.Point(240, 306);
            this.tbxAn2.MaxLength = 20;
            this.tbxAn2.Name = "tbxAn2";
            this.tbxAn2.Size = new System.Drawing.Size(465, 29);
            this.tbxAn2.TabIndex = 5;
            // 
            // lblSecurity3
            // 
            this.lblSecurity3.AutoSize = true;
            this.lblSecurity3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity3.Location = new System.Drawing.Point(8, 361);
            this.lblSecurity3.Name = "lblSecurity3";
            this.lblSecurity3.Size = new System.Drawing.Size(194, 22);
            this.lblSecurity3.TabIndex = 16;
            this.lblSecurity3.Text = "Security Question 3:";
            // 
            // lblSC3
            // 
            this.lblSC3.BackColor = System.Drawing.Color.White;
            this.lblSC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSC3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC3.Location = new System.Drawing.Point(240, 360);
            this.lblSC3.Name = "lblSC3";
            this.lblSC3.Size = new System.Drawing.Size(465, 29);
            this.lblSC3.TabIndex = 6;
            // 
            // lblAn3
            // 
            this.lblAn3.AutoSize = true;
            this.lblAn3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAn3.Location = new System.Drawing.Point(20, 422);
            this.lblAn3.Name = "lblAn3";
            this.lblAn3.Size = new System.Drawing.Size(182, 22);
            this.lblAn3.TabIndex = 17;
            this.lblAn3.Text = "Security Answer 3:";
            // 
            // tbxAn3
            // 
            this.tbxAn3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAn3.Location = new System.Drawing.Point(240, 419);
            this.tbxAn3.MaxLength = 20;
            this.tbxAn3.Name = "tbxAn3";
            this.tbxAn3.Size = new System.Drawing.Size(465, 29);
            this.tbxAn3.TabIndex = 7;
            // 
            // pbxPass1
            // 
            this.pbxPass1.Image = global::FA21_Final_Project.Properties.Resources.eye;
            this.pbxPass1.Location = new System.Drawing.Point(538, 12);
            this.pbxPass1.Name = "pbxPass1";
            this.pbxPass1.Size = new System.Drawing.Size(53, 43);
            this.pbxPass1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPass1.TabIndex = 22;
            this.pbxPass1.TabStop = false;
            this.pbxPass1.Click += new System.EventHandler(this.pbxPass1_Click);
            // 
            // pbxPass2
            // 
            this.pbxPass2.Image = global::FA21_Final_Project.Properties.Resources.eye;
            this.pbxPass2.Location = new System.Drawing.Point(538, 68);
            this.pbxPass2.Name = "pbxPass2";
            this.pbxPass2.Size = new System.Drawing.Size(53, 43);
            this.pbxPass2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPass2.TabIndex = 23;
            this.pbxPass2.TabStop = false;
            this.pbxPass2.Click += new System.EventHandler(this.pbxPass2_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.Location = new System.Drawing.Point(631, 12);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(44, 18);
            this.lblHelp.TabIndex = 24;
            this.lblHelp.Text = "&Help";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // frmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(717, 578);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.pbxPass2);
            this.Controls.Add(this.pbxPass1);
            this.Controls.Add(this.tbxAn3);
            this.Controls.Add(this.lblAn3);
            this.Controls.Add(this.lblSC3);
            this.Controls.Add(this.lblSecurity3);
            this.Controls.Add(this.tbxAn2);
            this.Controls.Add(this.lblAn2);
            this.Controls.Add(this.lblSC2);
            this.Controls.Add(this.lblSecurity2);
            this.Controls.Add(this.tbxAn1);
            this.Controls.Add(this.lblAn1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblSC1);
            this.Controls.Add(this.lblSecurity1);
            this.Controls.Add(this.tbxConfirm);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblNew);
            this.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.MaximizeBox = false;
            this.Name = "frmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Reset";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPassword_FormClosing);
            this.Load += new System.EventHandler(this.frmPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPass1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPass2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxConfirm;
        private System.Windows.Forms.Label lblSecurity1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSC1;
        private System.Windows.Forms.Label lblAn1;
        private System.Windows.Forms.TextBox tbxAn1;
        private System.Windows.Forms.Label lblSecurity2;
        private System.Windows.Forms.Label lblSC2;
        private System.Windows.Forms.Label lblAn2;
        private System.Windows.Forms.TextBox tbxAn2;
        private System.Windows.Forms.Label lblSecurity3;
        private System.Windows.Forms.Label lblSC3;
        private System.Windows.Forms.Label lblAn3;
        private System.Windows.Forms.TextBox tbxAn3;
        private System.Windows.Forms.PictureBox pbxPass1;
        private System.Windows.Forms.PictureBox pbxPass2;
        private System.Windows.Forms.HelpProvider hlpMain;
        private System.Windows.Forms.Label lblHelp;
    }
}