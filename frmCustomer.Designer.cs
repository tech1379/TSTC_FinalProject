
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
            this.btnCart = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbxQuantity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tbShoppingCart = new System.Windows.Forms.TabPage();
            this.lblDisc = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.tbxExpiration = new System.Windows.Forms.TextBox();
            this.lblExp = new System.Windows.Forms.Label();
            this.tbxCreditCard = new System.Windows.Forms.TextBox();
            this.lblCC = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCust = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblTaxes = new System.Windows.Forms.Label();
            this.lblTx = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblST = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblSBTD = new System.Windows.Forms.Label();
            this.lblSubTotalDisc = new System.Windows.Forms.Label();
            this.lblCCode = new System.Windows.Forms.Label();
            this.cbxCouponCode = new System.Windows.Forms.ComboBox();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.tbCustomer.SuspendLayout();
            this.tbInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.tbShoppingCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCustomer
            // 
            this.tbCustomer.Controls.Add(this.tbInventory);
            this.tbCustomer.Controls.Add(this.tbQuailHunts);
            this.tbCustomer.Controls.Add(this.tbTraining);
            this.tbCustomer.Controls.Add(this.tbShoppingCart);
            this.tbCustomer.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.Location = new System.Drawing.Point(13, 9);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.SelectedIndex = 0;
            this.tbCustomer.Size = new System.Drawing.Size(898, 572);
            this.tbCustomer.TabIndex = 0;
            // 
            // tbInventory
            // 
            this.tbInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbInventory.Controls.Add(this.btnCart);
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
            this.tbInventory.Location = new System.Drawing.Point(4, 28);
            this.tbInventory.Name = "tbInventory";
            this.tbInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tbInventory.Size = new System.Drawing.Size(890, 540);
            this.tbInventory.TabIndex = 0;
            this.tbInventory.Text = "Inventory";
            // 
            // btnCart
            // 
            this.btnCart.Location = new System.Drawing.Point(555, 452);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(90, 58);
            this.btnCart.TabIndex = 14;
            this.btnCart.Text = "&Go to Cart";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(412, 452);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 58);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "&Add to Cart";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbxQuantity
            // 
            this.cbxQuantity.FormattingEnabled = true;
            this.cbxQuantity.Location = new System.Drawing.Point(402, 339);
            this.cbxQuantity.Name = "cbxQuantity";
            this.cbxQuantity.Size = new System.Drawing.Size(121, 23);
            this.cbxQuantity.TabIndex = 12;
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
            this.tbQuailHunts.Location = new System.Drawing.Point(4, 28);
            this.tbQuailHunts.Name = "tbQuailHunts";
            this.tbQuailHunts.Padding = new System.Windows.Forms.Padding(3);
            this.tbQuailHunts.Size = new System.Drawing.Size(890, 464);
            this.tbQuailHunts.TabIndex = 1;
            this.tbQuailHunts.Text = "Quail Hunts";
            // 
            // tbTraining
            // 
            this.tbTraining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbTraining.Location = new System.Drawing.Point(4, 28);
            this.tbTraining.Name = "tbTraining";
            this.tbTraining.Padding = new System.Windows.Forms.Padding(3);
            this.tbTraining.Size = new System.Drawing.Size(890, 464);
            this.tbTraining.TabIndex = 2;
            this.tbTraining.Text = "Training Services";
            // 
            // tbShoppingCart
            // 
            this.tbShoppingCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbShoppingCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbShoppingCart.Controls.Add(this.btnReceipt);
            this.tbShoppingCart.Controls.Add(this.cbxCouponCode);
            this.tbShoppingCart.Controls.Add(this.lblCCode);
            this.tbShoppingCart.Controls.Add(this.lblSubTotalDisc);
            this.tbShoppingCart.Controls.Add(this.lblSBTD);
            this.tbShoppingCart.Controls.Add(this.lblDisc);
            this.tbShoppingCart.Controls.Add(this.lblDiscount);
            this.tbShoppingCart.Controls.Add(this.tbxExpiration);
            this.tbShoppingCart.Controls.Add(this.lblExp);
            this.tbShoppingCart.Controls.Add(this.tbxCreditCard);
            this.tbShoppingCart.Controls.Add(this.lblCC);
            this.tbShoppingCart.Controls.Add(this.btnRemove);
            this.tbShoppingCart.Controls.Add(this.btnOrder);
            this.tbShoppingCart.Controls.Add(this.lblCustomer);
            this.tbShoppingCart.Controls.Add(this.lblCust);
            this.tbShoppingCart.Controls.Add(this.lblTotal);
            this.tbShoppingCart.Controls.Add(this.lblT1);
            this.tbShoppingCart.Controls.Add(this.lblTaxes);
            this.tbShoppingCart.Controls.Add(this.lblTx);
            this.tbShoppingCart.Controls.Add(this.lblSubTotal);
            this.tbShoppingCart.Controls.Add(this.lblST);
            this.tbShoppingCart.Controls.Add(this.dgvResults);
            this.tbShoppingCart.Location = new System.Drawing.Point(4, 28);
            this.tbShoppingCart.Name = "tbShoppingCart";
            this.tbShoppingCart.Padding = new System.Windows.Forms.Padding(3);
            this.tbShoppingCart.Size = new System.Drawing.Size(890, 540);
            this.tbShoppingCart.TabIndex = 3;
            this.tbShoppingCart.Text = "Shopping Cart";
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisc.Location = new System.Drawing.Point(613, 354);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(91, 19);
            this.lblDisc.TabIndex = 16;
            this.lblDisc.Text = "Discount:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.BackColor = System.Drawing.Color.White;
            this.lblDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiscount.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(728, 346);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(122, 27);
            this.lblDiscount.TabIndex = 15;
            // 
            // tbxExpiration
            // 
            this.tbxExpiration.Location = new System.Drawing.Point(10, 244);
            this.tbxExpiration.MaxLength = 5;
            this.tbxExpiration.Name = "tbxExpiration";
            this.tbxExpiration.Size = new System.Drawing.Size(226, 26);
            this.tbxExpiration.TabIndex = 14;
            this.tbxExpiration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxExpiration_KeyPress);
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.Location = new System.Drawing.Point(6, 208);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(153, 19);
            this.lblExp.TabIndex = 13;
            this.lblExp.Text = "Expiration Date:";
            // 
            // tbxCreditCard
            // 
            this.tbxCreditCard.Location = new System.Drawing.Point(10, 166);
            this.tbxCreditCard.MaxLength = 19;
            this.tbxCreditCard.Name = "tbxCreditCard";
            this.tbxCreditCard.Size = new System.Drawing.Size(226, 26);
            this.tbxCreditCard.TabIndex = 12;
            this.tbxCreditCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCreditCard_KeyPress);
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(6, 130);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(191, 19);
            this.lblCC.TabIndex = 11;
            this.lblCC.Text = "Credit Card Number:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(95, 468);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(102, 49);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "&Remove Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(239, 468);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(102, 49);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.Text = "&Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(6, 64);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(230, 39);
            this.lblCustomer.TabIndex = 8;
            // 
            // lblCust
            // 
            this.lblCust.AutoSize = true;
            this.lblCust.Location = new System.Drawing.Point(6, 17);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(99, 19);
            this.lblCust.TabIndex = 7;
            this.lblCust.Text = "Customer:";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(728, 490);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(122, 27);
            this.lblTotal.TabIndex = 6;
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT1.Location = new System.Drawing.Point(638, 498);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(60, 19);
            this.lblT1.TabIndex = 5;
            this.lblT1.Text = "Total:";
            // 
            // lblTaxes
            // 
            this.lblTaxes.BackColor = System.Drawing.Color.White;
            this.lblTaxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTaxes.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxes.Location = new System.Drawing.Point(728, 437);
            this.lblTaxes.Name = "lblTaxes";
            this.lblTaxes.Size = new System.Drawing.Size(122, 27);
            this.lblTaxes.TabIndex = 4;
            // 
            // lblTx
            // 
            this.lblTx.AutoSize = true;
            this.lblTx.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTx.Location = new System.Drawing.Point(638, 445);
            this.lblTx.Name = "lblTx";
            this.lblTx.Size = new System.Drawing.Size(66, 19);
            this.lblTx.TabIndex = 3;
            this.lblTx.Text = "Taxes:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.White;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(728, 304);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(122, 27);
            this.lblSubTotal.TabIndex = 2;
            // 
            // lblST
            // 
            this.lblST.AutoSize = true;
            this.lblST.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblST.Location = new System.Drawing.Point(613, 312);
            this.lblST.Name = "lblST";
            this.lblST.Size = new System.Drawing.Size(98, 19);
            this.lblST.TabIndex = 1;
            this.lblST.Text = "Sub Total:";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvResults.Location = new System.Drawing.Point(253, 34);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(616, 257);
            this.dgvResults.TabIndex = 0;
            // 
            // lblSBTD
            // 
            this.lblSBTD.AutoSize = true;
            this.lblSBTD.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSBTD.Location = new System.Drawing.Point(479, 397);
            this.lblSBTD.Name = "lblSBTD";
            this.lblSBTD.Size = new System.Drawing.Size(225, 19);
            this.lblSBTD.TabIndex = 17;
            this.lblSBTD.Text = "Sub Total After Discount:";
            // 
            // lblSubTotalDisc
            // 
            this.lblSubTotalDisc.BackColor = System.Drawing.Color.White;
            this.lblSubTotalDisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotalDisc.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalDisc.Location = new System.Drawing.Point(728, 389);
            this.lblSubTotalDisc.Name = "lblSubTotalDisc";
            this.lblSubTotalDisc.Size = new System.Drawing.Size(122, 27);
            this.lblSubTotalDisc.TabIndex = 18;
            // 
            // lblCCode
            // 
            this.lblCCode.AutoSize = true;
            this.lblCCode.Location = new System.Drawing.Point(19, 312);
            this.lblCCode.Name = "lblCCode";
            this.lblCCode.Size = new System.Drawing.Size(129, 19);
            this.lblCCode.TabIndex = 19;
            this.lblCCode.Text = "Coupon Code:";
            // 
            // cbxCouponCode
            // 
            this.cbxCouponCode.FormattingEnabled = true;
            this.cbxCouponCode.Location = new System.Drawing.Point(23, 346);
            this.cbxCouponCode.Name = "cbxCouponCode";
            this.cbxCouponCode.Size = new System.Drawing.Size(121, 27);
            this.cbxCouponCode.TabIndex = 20;
            // 
            // btnReceipt
            // 
            this.btnReceipt.Location = new System.Drawing.Point(379, 468);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(102, 49);
            this.btnReceipt.TabIndex = 21;
            this.btnReceipt.Text = "&Print Receipt";
            this.btnReceipt.UseVisualStyleBackColor = true;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(923, 593);
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
            this.tbShoppingCart.ResumeLayout(false);
            this.tbShoppingCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblST;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblTaxes;
        private System.Windows.Forms.Label lblTx;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.TextBox tbxCreditCard;
        private System.Windows.Forms.TextBox tbxExpiration;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.Label lblDisc;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblSBTD;
        private System.Windows.Forms.Label lblSubTotalDisc;
        private System.Windows.Forms.Label lblCCode;
        private System.Windows.Forms.ComboBox cbxCouponCode;
        private System.Windows.Forms.Button btnReceipt;
    }
}