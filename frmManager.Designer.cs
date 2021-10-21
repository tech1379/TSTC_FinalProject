﻿
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRestock = new System.Windows.Forms.Button();
            this.tbManager.SuspendLayout();
            this.tbInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tbManager
            // 
            this.tbManager.Controls.Add(this.tbInventory);
            this.tbManager.Controls.Add(this.tabPage2);
            this.tbManager.Location = new System.Drawing.Point(23, 48);
            this.tbManager.Name = "tbManager";
            this.tbManager.SelectedIndex = 0;
            this.tbManager.Size = new System.Drawing.Size(857, 411);
            this.tbManager.TabIndex = 0;
            // 
            // tbInventory
            // 
            this.tbInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
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
            this.btnInventory.Text = "&Change Amount";
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(849, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbManager;
        private System.Windows.Forms.TabPage tbInventory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRestock;
    }
}