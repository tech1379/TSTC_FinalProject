
namespace FA21_Final_Project
{
    partial class frmAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd));
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.lblRetailPrice = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.tbxItemDesc = new System.Windows.Forms.TextBox();
            this.tbxRetailPrice = new System.Windows.Forms.TextBox();
            this.tbxCost = new System.Windows.Forms.TextBox();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(92, 50);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(98, 18);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Item Name:";
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.Location = new System.Drawing.Point(46, 94);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(144, 18);
            this.lblItemDesc.TabIndex = 1;
            this.lblItemDesc.Text = "Item Description:";
            // 
            // lblRetailPrice
            // 
            this.lblRetailPrice.AutoSize = true;
            this.lblRetailPrice.Location = new System.Drawing.Point(85, 138);
            this.lblRetailPrice.Name = "lblRetailPrice";
            this.lblRetailPrice.Size = new System.Drawing.Size(105, 18);
            this.lblRetailPrice.TabIndex = 2;
            this.lblRetailPrice.Text = "Retail Price:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(140, 182);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(50, 18);
            this.lblCost.TabIndex = 3;
            this.lblCost.Text = "Cost:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(109, 226);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(81, 18);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity:";
            // 
            // tbxItemName
            // 
            this.tbxItemName.Location = new System.Drawing.Point(228, 42);
            this.tbxItemName.MaxLength = 100;
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(356, 26);
            this.tbxItemName.TabIndex = 5;
            this.tbxItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxItemName_KeyPress);
            // 
            // tbxItemDesc
            // 
            this.tbxItemDesc.Location = new System.Drawing.Point(228, 86);
            this.tbxItemDesc.MaxLength = 1000;
            this.tbxItemDesc.Name = "tbxItemDesc";
            this.tbxItemDesc.Size = new System.Drawing.Size(356, 26);
            this.tbxItemDesc.TabIndex = 6;
            this.tbxItemDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxItemDesc_KeyPress);
            // 
            // tbxRetailPrice
            // 
            this.tbxRetailPrice.Location = new System.Drawing.Point(228, 130);
            this.tbxRetailPrice.MaxLength = 9;
            this.tbxRetailPrice.Name = "tbxRetailPrice";
            this.tbxRetailPrice.Size = new System.Drawing.Size(356, 26);
            this.tbxRetailPrice.TabIndex = 7;
            this.tbxRetailPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxRetailPrice_KeyPress);
            // 
            // tbxCost
            // 
            this.tbxCost.Location = new System.Drawing.Point(228, 174);
            this.tbxCost.MaxLength = 9;
            this.tbxCost.Name = "tbxCost";
            this.tbxCost.Size = new System.Drawing.Size(356, 26);
            this.tbxCost.TabIndex = 8;
            this.tbxCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCost_KeyPress);
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Location = new System.Drawing.Point(228, 218);
            this.tbxQuantity.MaxLength = 9;
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(356, 26);
            this.tbxQuantity.TabIndex = 9;
            this.tbxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxQuantity_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(212, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 59);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(382, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 59);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(677, 340);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxQuantity);
            this.Controls.Add(this.tbxCost);
            this.Controls.Add(this.tbxRetailPrice);
            this.Controls.Add(this.tbxItemDesc);
            this.Controls.Add(this.tbxItemName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblRetailPrice);
            this.Controls.Add(this.lblItemDesc);
            this.Controls.Add(this.lblItemName);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Inventory Item";
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.Label lblRetailPrice;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.TextBox tbxItemDesc;
        private System.Windows.Forms.TextBox tbxRetailPrice;
        private System.Windows.Forms.TextBox tbxCost;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
    }
}