
namespace FA21_Final_Project
{
    partial class frmCustomer
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
            this.tbCustomer = new System.Windows.Forms.TabControl();
            this.tbInventory = new System.Windows.Forms.TabPage();
            this.pbxNext = new System.Windows.Forms.PictureBox();
            this.pbxPrevious = new System.Windows.Forms.PictureBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblOne = new System.Windows.Forms.Label();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.tbQuailHunts = new System.Windows.Forms.TabPage();
            this.tbTraining = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxQuantity = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbShoppingCart = new System.Windows.Forms.TabPage();
            this.tbCustomer.SuspendLayout();
            this.tbInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCustomer
            // 
            this.tbCustomer.Controls.Add(this.tbInventory);
            this.tbCustomer.Controls.Add(this.tbQuailHunts);
            this.tbCustomer.Controls.Add(this.tbTraining);
            this.tbCustomer.Controls.Add(this.tbShoppingCart);
            this.tbCustomer.Location = new System.Drawing.Point(13, 9);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.SelectedIndex = 0;
            this.tbCustomer.Size = new System.Drawing.Size(898, 496);
            this.tbCustomer.TabIndex = 0;
            // 
            // tbInventory
            // 
            this.tbInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbInventory.Controls.Add(this.btnAdd);
            this.tbInventory.Controls.Add(this.cbxQuantity);
            this.tbInventory.Controls.Add(this.label1);
            this.tbInventory.Controls.Add(this.pbxNext);
            this.tbInventory.Controls.Add(this.pbxPrevious);
            this.tbInventory.Controls.Add(this.lblQuantity);
            this.tbInventory.Controls.Add(this.lblCost);
            this.tbInventory.Controls.Add(this.lblDescription);
            this.tbInventory.Controls.Add(this.lblName);
            this.tbInventory.Controls.Add(this.lbl4);
            this.tbInventory.Controls.Add(this.lbl3);
            this.tbInventory.Controls.Add(this.lbl2);
            this.tbInventory.Controls.Add(this.lblOne);
            this.tbInventory.Controls.Add(this.pbxImage);
            this.tbInventory.Font = new System.Drawing.Font("Broadway", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInventory.Location = new System.Drawing.Point(4, 22);
            this.tbInventory.Name = "tbInventory";
            this.tbInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tbInventory.Size = new System.Drawing.Size(890, 470);
            this.tbInventory.TabIndex = 0;
            this.tbInventory.Text = "Inventory";
            // 
            // pbxNext
            // 
            this.pbxNext.Image = global::FA21_Final_Project.Properties.Resources.next;
            this.pbxNext.Location = new System.Drawing.Point(292, 339);
            this.pbxNext.Name = "pbxNext";
            this.pbxNext.Size = new System.Drawing.Size(62, 50);
            this.pbxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNext.TabIndex = 10;
            this.pbxNext.TabStop = false;
            this.pbxNext.Click += new System.EventHandler(this.pbxNext_Click);
            // 
            // pbxPrevious
            // 
            this.pbxPrevious.Image = global::FA21_Final_Project.Properties.Resources.previous;
            this.pbxPrevious.Location = new System.Drawing.Point(107, 339);
            this.pbxPrevious.Name = "pbxPrevious";
            this.pbxPrevious.Size = new System.Drawing.Size(62, 50);
            this.pbxPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPrevious.TabIndex = 9;
            this.pbxPrevious.TabStop = false;
            this.pbxPrevious.Click += new System.EventHandler(this.pbxPrevious_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQuantity.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(518, 256);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(292, 30);
            this.lblQuantity.TabIndex = 8;
            // 
            // lblCost
            // 
            this.lblCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblCost.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(518, 197);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(292, 30);
            this.lblCost.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblDescription.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(517, 138);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(292, 76);
            this.lblDescription.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblName.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(517, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(367, 55);
            this.lblName.TabIndex = 5;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(398, 256);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(86, 19);
            this.lbl4.TabIndex = 4;
            this.lbl4.Text = "In Stock:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(439, 197);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(51, 19);
            this.lbl3.TabIndex = 3;
            this.lbl3.Text = "Cost:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(375, 138);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(115, 19);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Description:";
            // 
            // lblOne
            // 
            this.lblOne.AutoSize = true;
            this.lblOne.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOne.Location = new System.Drawing.Point(392, 61);
            this.lblOne.Name = "lblOne";
            this.lblOne.Size = new System.Drawing.Size(98, 27);
            this.lblOne.TabIndex = 1;
            this.lblOne.Text = "Name:";
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(107, 78);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(247, 217);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            // 
            // tbQuailHunts
            // 
            this.tbQuailHunts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbQuailHunts.Location = new System.Drawing.Point(4, 22);
            this.tbQuailHunts.Name = "tbQuailHunts";
            this.tbQuailHunts.Padding = new System.Windows.Forms.Padding(3);
            this.tbQuailHunts.Size = new System.Drawing.Size(890, 470);
            this.tbQuailHunts.TabIndex = 1;
            this.tbQuailHunts.Text = "Quail Hunts";
            // 
            // tbTraining
            // 
            this.tbTraining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbTraining.Location = new System.Drawing.Point(4, 22);
            this.tbTraining.Name = "tbTraining";
            this.tbTraining.Padding = new System.Windows.Forms.Padding(3);
            this.tbTraining.Size = new System.Drawing.Size(890, 470);
            this.tbTraining.TabIndex = 2;
            this.tbTraining.Text = "Training Services";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Please select the amount you want to buy:";
            // 
            // cbxQuantity
            // 
            this.cbxQuantity.FormattingEnabled = true;
            this.cbxQuantity.Location = new System.Drawing.Point(402, 339);
            this.cbxQuantity.Name = "cbxQuantity";
            this.cbxQuantity.Size = new System.Drawing.Size(121, 23);
            this.cbxQuantity.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(402, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 40);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "&Add to Cart";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // tbShoppingCart
            // 
            this.tbShoppingCart.Location = new System.Drawing.Point(4, 22);
            this.tbShoppingCart.Name = "tbShoppingCart";
            this.tbShoppingCart.Padding = new System.Windows.Forms.Padding(3);
            this.tbShoppingCart.Size = new System.Drawing.Size(890, 470);
            this.tbShoppingCart.TabIndex = 3;
            this.tbShoppingCart.Text = "Shopping Cart";
            this.tbShoppingCart.UseVisualStyleBackColor = true;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(923, 517);
            this.Controls.Add(this.tbCustomer);
            this.MaximizeBox = false;
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Portal";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.tbCustomer.ResumeLayout(false);
            this.tbInventory.ResumeLayout(false);
            this.tbInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbCustomer;
        private System.Windows.Forms.TabPage tbInventory;
        private System.Windows.Forms.TabPage tbQuailHunts;
        private System.Windows.Forms.TabPage tbTraining;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label lblOne;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.PictureBox pbxPrevious;
        private System.Windows.Forms.PictureBox pbxNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabPage tbShoppingCart;
    }
}