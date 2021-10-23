
namespace FA21_Final_Project
{
    partial class frmManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.tbManager = new System.Windows.Forms.TabControl();
            this.tbInventory = new System.Windows.Forms.TabPage();
            this.btnRestock = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.tbManagerInfo = new System.Windows.Forms.TabPage();
            this.dgvResults2 = new System.Windows.Forms.DataGridView();
            this.btnAddManager = new System.Windows.Forms.Button();
            this.btnUpdateManager = new System.Windows.Forms.Button();
            this.btnRemoveManager = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnHelp1 = new System.Windows.Forms.Label();
            this.btnHelp2 = new System.Windows.Forms.Label();
            this.hlpManagerInventory = new System.Windows.Forms.HelpProvider();
            this.hlpManagerManager = new System.Windows.Forms.HelpProvider();
            this.tbManager.SuspendLayout();
            this.tbInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tbManagerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbManager
            // 
            this.tbManager.Controls.Add(this.tbInventory);
            this.tbManager.Controls.Add(this.tbManagerInfo);
            this.tbManager.Location = new System.Drawing.Point(23, 48);
            this.tbManager.Name = "tbManager";
            this.tbManager.SelectedIndex = 0;
            this.tbManager.Size = new System.Drawing.Size(857, 411);
            this.tbManager.TabIndex = 0;
            // 
            // tbInventory
            // 
            this.tbInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbInventory.Controls.Add(this.btnHelp1);
            this.tbInventory.Controls.Add(this.btnRestock);
            this.tbInventory.Controls.Add(this.btnRemove);
            this.tbInventory.Controls.Add(this.btnAdd);
            this.tbInventory.Controls.Add(this.btnInventory);
            this.tbInventory.Controls.Add(this.dgvResults);
            this.tbInventory.Location = new System.Drawing.Point(4, 27);
            this.tbInventory.Name = "tbInventory";
            this.tbInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tbInventory.Size = new System.Drawing.Size(849, 380);
            this.tbInventory.TabIndex = 0;
            this.tbInventory.Text = "Inventory";
            // 
            // btnRestock
            // 
            this.btnRestock.Location = new System.Drawing.Point(136, 302);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(96, 64);
            this.btnRestock.TabIndex = 4;
            this.btnRestock.Text = "&Check Inventory";
            this.btnRestock.UseVisualStyleBackColor = true;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(617, 302);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(96, 64);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "&Remove Product";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnRemove.MouseHover += new System.EventHandler(this.btnRemove_MouseHover);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(463, 302);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 64);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add Product";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(305, 302);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(96, 64);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "Change Amoun&t";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            this.btnInventory.MouseHover += new System.EventHandler(this.btnInventory_MouseHover);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(33, 34);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(783, 222);
            this.dgvResults.TabIndex = 0;
            // 
            // tbManagerInfo
            // 
            this.tbManagerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbManagerInfo.Controls.Add(this.btnHelp2);
            this.tbManagerInfo.Controls.Add(this.btnDisable);
            this.tbManagerInfo.Controls.Add(this.btnRemoveManager);
            this.tbManagerInfo.Controls.Add(this.btnUpdateManager);
            this.tbManagerInfo.Controls.Add(this.btnAddManager);
            this.tbManagerInfo.Controls.Add(this.dgvResults2);
            this.tbManagerInfo.Location = new System.Drawing.Point(4, 27);
            this.tbManagerInfo.Name = "tbManagerInfo";
            this.tbManagerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbManagerInfo.Size = new System.Drawing.Size(849, 380);
            this.tbManagerInfo.TabIndex = 1;
            this.tbManagerInfo.Text = "Managers";
            // 
            // dgvResults2
            // 
            this.dgvResults2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults2.Location = new System.Drawing.Point(32, 43);
            this.dgvResults2.Name = "dgvResults2";
            this.dgvResults2.Size = new System.Drawing.Size(790, 225);
            this.dgvResults2.TabIndex = 0;
            // 
            // btnAddManager
            // 
            this.btnAddManager.Location = new System.Drawing.Point(138, 291);
            this.btnAddManager.Name = "btnAddManager";
            this.btnAddManager.Size = new System.Drawing.Size(96, 64);
            this.btnAddManager.TabIndex = 5;
            this.btnAddManager.Text = "Add &Manager";
            this.btnAddManager.UseVisualStyleBackColor = true;
            this.btnAddManager.Click += new System.EventHandler(this.btnAddManager_Click);
            // 
            // btnUpdateManager
            // 
            this.btnUpdateManager.Location = new System.Drawing.Point(297, 291);
            this.btnUpdateManager.Name = "btnUpdateManager";
            this.btnUpdateManager.Size = new System.Drawing.Size(96, 64);
            this.btnUpdateManager.TabIndex = 6;
            this.btnUpdateManager.Text = "&Update Manager";
            this.btnUpdateManager.UseVisualStyleBackColor = true;
            this.btnUpdateManager.Click += new System.EventHandler(this.btnUpdateManager_Click);
            this.btnUpdateManager.MouseHover += new System.EventHandler(this.btnUpdateManager_MouseHover);
            // 
            // btnRemoveManager
            // 
            this.btnRemoveManager.Location = new System.Drawing.Point(456, 291);
            this.btnRemoveManager.Name = "btnRemoveManager";
            this.btnRemoveManager.Size = new System.Drawing.Size(96, 64);
            this.btnRemoveManager.TabIndex = 7;
            this.btnRemoveManager.Text = "Remo&ve Manager";
            this.btnRemoveManager.UseVisualStyleBackColor = true;
            this.btnRemoveManager.Click += new System.EventHandler(this.btnRemoveManager_Click);
            this.btnRemoveManager.MouseHover += new System.EventHandler(this.btnRemoveManager_MouseHover);
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(615, 291);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(96, 64);
            this.btnDisable.TabIndex = 8;
            this.btnDisable.Text = "&Disable Account";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            this.btnDisable.MouseHover += new System.EventHandler(this.btnDisable_MouseHover);
            // 
            // btnHelp1
            // 
            this.btnHelp1.AutoSize = true;
            this.btnHelp1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp1.Location = new System.Drawing.Point(15, 3);
            this.btnHelp1.Name = "btnHelp1";
            this.btnHelp1.Size = new System.Drawing.Size(44, 18);
            this.btnHelp1.TabIndex = 5;
            this.btnHelp1.Text = "&Help";
            this.btnHelp1.Click += new System.EventHandler(this.btnHelp1_Click);
            // 
            // btnHelp2
            // 
            this.btnHelp2.AutoSize = true;
            this.btnHelp2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp2.Location = new System.Drawing.Point(29, 12);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(44, 18);
            this.btnHelp2.TabIndex = 9;
            this.btnHelp2.Text = "&Help";
            this.btnHelp2.Click += new System.EventHandler(this.btnHelp2_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(925, 487);
            this.Controls.Add(this.tbManager);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManager";
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.tbManager.ResumeLayout(false);
            this.tbInventory.ResumeLayout(false);
            this.tbInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tbManagerInfo.ResumeLayout(false);
            this.tbManagerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbManager;
        private System.Windows.Forms.TabPage tbInventory;
        private System.Windows.Forms.TabPage tbManagerInfo;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.DataGridView dgvResults2;
        private System.Windows.Forms.Button btnAddManager;
        private System.Windows.Forms.Button btnUpdateManager;
        private System.Windows.Forms.Button btnRemoveManager;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Label btnHelp1;
        private System.Windows.Forms.Label btnHelp2;
        private System.Windows.Forms.HelpProvider hlpManagerInventory;
        private System.Windows.Forms.HelpProvider hlpManagerManager;
    }
}