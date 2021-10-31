
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
            this.btnHelp1 = new System.Windows.Forms.Label();
            this.btnRestock = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.tbManagerInfo = new System.Windows.Forms.TabPage();
            this.btnHelp2 = new System.Windows.Forms.Label();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnRemoveManager = new System.Windows.Forms.Button();
            this.btnUpdateManager = new System.Windows.Forms.Button();
            this.btnAddManager = new System.Windows.Forms.Button();
            this.dgvResults2 = new System.Windows.Forms.DataGridView();
            this.tbManagerCustomer = new System.Windows.Forms.TabPage();
            this.btnCustomerHelp = new System.Windows.Forms.Label();
            this.btnOrderCustomer = new System.Windows.Forms.Button();
            this.btnDisableCustomer = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.dgvResults3 = new System.Windows.Forms.DataGridView();
            this.tbCoupons = new System.Windows.Forms.TabPage();
            this.btnCouponHelp = new System.Windows.Forms.Label();
            this.mthExpiration = new System.Windows.Forms.MonthCalendar();
            this.tbxCouponPercent = new System.Windows.Forms.TextBox();
            this.lblCouponExpiration = new System.Windows.Forms.Label();
            this.lblCouponPercent = new System.Windows.Forms.Label();
            this.btnEditCoupon = new System.Windows.Forms.Button();
            this.btnRemoveCoupon = new System.Windows.Forms.Button();
            this.btnAddCoupon = new System.Windows.Forms.Button();
            this.dgvResults4 = new System.Windows.Forms.DataGridView();
            this.hlpManagerInventory = new System.Windows.Forms.HelpProvider();
            this.hlpManagerManager = new System.Windows.Forms.HelpProvider();
            this.hlpManagerCustomer = new System.Windows.Forms.HelpProvider();
            this.hlpManagerCoupon = new System.Windows.Forms.HelpProvider();
            this.tbReports = new System.Windows.Forms.TabPage();
            this.btnDaily = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnManagers = new System.Windows.Forms.Button();
            this.btnInventoryReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.mthCalendar = new System.Windows.Forms.MonthCalendar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tbManager.SuspendLayout();
            this.tbInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tbManagerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults2)).BeginInit();
            this.tbManagerCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults3)).BeginInit();
            this.tbCoupons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults4)).BeginInit();
            this.tbReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbManager
            // 
            this.tbManager.Controls.Add(this.tbInventory);
            this.tbManager.Controls.Add(this.tbManagerInfo);
            this.tbManager.Controls.Add(this.tbManagerCustomer);
            this.tbManager.Controls.Add(this.tbCoupons);
            this.tbManager.Controls.Add(this.tbReports);
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
            // dgvResults2
            // 
            this.dgvResults2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults2.Location = new System.Drawing.Point(32, 43);
            this.dgvResults2.Name = "dgvResults2";
            this.dgvResults2.Size = new System.Drawing.Size(790, 225);
            this.dgvResults2.TabIndex = 0;
            // 
            // tbManagerCustomer
            // 
            this.tbManagerCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbManagerCustomer.Controls.Add(this.btnCustomerHelp);
            this.tbManagerCustomer.Controls.Add(this.btnOrderCustomer);
            this.tbManagerCustomer.Controls.Add(this.btnDisableCustomer);
            this.tbManagerCustomer.Controls.Add(this.btnRemoveCustomer);
            this.tbManagerCustomer.Controls.Add(this.btnUpdateCustomer);
            this.tbManagerCustomer.Controls.Add(this.btnAddCustomer);
            this.tbManagerCustomer.Controls.Add(this.dgvResults3);
            this.tbManagerCustomer.Location = new System.Drawing.Point(4, 27);
            this.tbManagerCustomer.Name = "tbManagerCustomer";
            this.tbManagerCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tbManagerCustomer.Size = new System.Drawing.Size(849, 380);
            this.tbManagerCustomer.TabIndex = 2;
            this.tbManagerCustomer.Text = "Customer";
            // 
            // btnCustomerHelp
            // 
            this.btnCustomerHelp.AutoSize = true;
            this.btnCustomerHelp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerHelp.Location = new System.Drawing.Point(12, 17);
            this.btnCustomerHelp.Name = "btnCustomerHelp";
            this.btnCustomerHelp.Size = new System.Drawing.Size(44, 18);
            this.btnCustomerHelp.TabIndex = 11;
            this.btnCustomerHelp.Text = "&Help";
            this.btnCustomerHelp.Click += new System.EventHandler(this.btnCustomerHelp_Click);
            // 
            // btnOrderCustomer
            // 
            this.btnOrderCustomer.Location = new System.Drawing.Point(652, 301);
            this.btnOrderCustomer.Name = "btnOrderCustomer";
            this.btnOrderCustomer.Size = new System.Drawing.Size(96, 64);
            this.btnOrderCustomer.TabIndex = 10;
            this.btnOrderCustomer.Text = "Customer &Order";
            this.btnOrderCustomer.UseVisualStyleBackColor = true;
            this.btnOrderCustomer.Click += new System.EventHandler(this.btnOrderCustomer_Click);
            this.btnOrderCustomer.MouseHover += new System.EventHandler(this.btnOrderCustomer_MouseHover);
            // 
            // btnDisableCustomer
            // 
            this.btnDisableCustomer.Location = new System.Drawing.Point(514, 301);
            this.btnDisableCustomer.Name = "btnDisableCustomer";
            this.btnDisableCustomer.Size = new System.Drawing.Size(96, 64);
            this.btnDisableCustomer.TabIndex = 9;
            this.btnDisableCustomer.Text = "&Disable Customer";
            this.btnDisableCustomer.UseVisualStyleBackColor = true;
            this.btnDisableCustomer.Click += new System.EventHandler(this.btnDisableCustomer_Click);
            this.btnDisableCustomer.MouseHover += new System.EventHandler(this.btnDisableCustomer_MouseHover);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Location = new System.Drawing.Point(376, 301);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(96, 64);
            this.btnRemoveCustomer.TabIndex = 8;
            this.btnRemoveCustomer.Text = "&Remove Customer";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            this.btnRemoveCustomer.MouseHover += new System.EventHandler(this.btnRemoveCustomer_MouseHover);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(238, 301);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(96, 64);
            this.btnUpdateCustomer.TabIndex = 7;
            this.btnUpdateCustomer.Text = "&Update Customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            this.btnUpdateCustomer.MouseHover += new System.EventHandler(this.btnUpdateCustomer_MouseHover);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(100, 301);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(96, 64);
            this.btnAddCustomer.TabIndex = 6;
            this.btnAddCustomer.Text = "Add Cus&tomer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // dgvResults3
            // 
            this.dgvResults3.AllowUserToAddRows = false;
            this.dgvResults3.AllowUserToDeleteRows = false;
            this.dgvResults3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults3.Location = new System.Drawing.Point(15, 56);
            this.dgvResults3.Name = "dgvResults3";
            this.dgvResults3.ReadOnly = true;
            this.dgvResults3.Size = new System.Drawing.Size(815, 227);
            this.dgvResults3.TabIndex = 0;
            // 
            // tbCoupons
            // 
            this.tbCoupons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbCoupons.Controls.Add(this.btnCouponHelp);
            this.tbCoupons.Controls.Add(this.mthExpiration);
            this.tbCoupons.Controls.Add(this.tbxCouponPercent);
            this.tbCoupons.Controls.Add(this.lblCouponExpiration);
            this.tbCoupons.Controls.Add(this.lblCouponPercent);
            this.tbCoupons.Controls.Add(this.btnEditCoupon);
            this.tbCoupons.Controls.Add(this.btnRemoveCoupon);
            this.tbCoupons.Controls.Add(this.btnAddCoupon);
            this.tbCoupons.Controls.Add(this.dgvResults4);
            this.tbCoupons.Location = new System.Drawing.Point(4, 27);
            this.tbCoupons.Name = "tbCoupons";
            this.tbCoupons.Padding = new System.Windows.Forms.Padding(3);
            this.tbCoupons.Size = new System.Drawing.Size(849, 380);
            this.tbCoupons.TabIndex = 3;
            this.tbCoupons.Text = "Coupons";
            // 
            // btnCouponHelp
            // 
            this.btnCouponHelp.AutoSize = true;
            this.btnCouponHelp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCouponHelp.Location = new System.Drawing.Point(15, 19);
            this.btnCouponHelp.Name = "btnCouponHelp";
            this.btnCouponHelp.Size = new System.Drawing.Size(44, 18);
            this.btnCouponHelp.TabIndex = 16;
            this.btnCouponHelp.Text = "&Help";
            this.btnCouponHelp.Click += new System.EventHandler(this.btnCouponHelp_Click);
            // 
            // mthExpiration
            // 
            this.mthExpiration.Location = new System.Drawing.Point(18, 193);
            this.mthExpiration.Name = "mthExpiration";
            this.mthExpiration.TabIndex = 15;
            // 
            // tbxCouponPercent
            // 
            this.tbxCouponPercent.Location = new System.Drawing.Point(18, 116);
            this.tbxCouponPercent.Name = "tbxCouponPercent";
            this.tbxCouponPercent.Size = new System.Drawing.Size(100, 26);
            this.tbxCouponPercent.TabIndex = 14;
            this.tbxCouponPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCouponPercent_KeyPress);
            // 
            // lblCouponExpiration
            // 
            this.lblCouponExpiration.AutoSize = true;
            this.lblCouponExpiration.Location = new System.Drawing.Point(15, 166);
            this.lblCouponExpiration.Name = "lblCouponExpiration";
            this.lblCouponExpiration.Size = new System.Drawing.Size(135, 18);
            this.lblCouponExpiration.TabIndex = 12;
            this.lblCouponExpiration.Text = "Expiration Date:";
            // 
            // lblCouponPercent
            // 
            this.lblCouponPercent.AutoSize = true;
            this.lblCouponPercent.Location = new System.Drawing.Point(15, 95);
            this.lblCouponPercent.Name = "lblCouponPercent";
            this.lblCouponPercent.Size = new System.Drawing.Size(143, 18);
            this.lblCouponPercent.TabIndex = 11;
            this.lblCouponPercent.Text = "Coupon Percent:";
            // 
            // btnEditCoupon
            // 
            this.btnEditCoupon.Location = new System.Drawing.Point(575, 276);
            this.btnEditCoupon.Name = "btnEditCoupon";
            this.btnEditCoupon.Size = new System.Drawing.Size(96, 64);
            this.btnEditCoupon.TabIndex = 9;
            this.btnEditCoupon.Text = "&Edit Coupon";
            this.btnEditCoupon.UseVisualStyleBackColor = true;
            this.btnEditCoupon.Click += new System.EventHandler(this.btnEditCoupon_Click);
            this.btnEditCoupon.MouseHover += new System.EventHandler(this.btnEditCoupon_MouseHover);
            // 
            // btnRemoveCoupon
            // 
            this.btnRemoveCoupon.Location = new System.Drawing.Point(734, 276);
            this.btnRemoveCoupon.Name = "btnRemoveCoupon";
            this.btnRemoveCoupon.Size = new System.Drawing.Size(96, 64);
            this.btnRemoveCoupon.TabIndex = 8;
            this.btnRemoveCoupon.Text = "&Remove Coupon";
            this.btnRemoveCoupon.UseVisualStyleBackColor = true;
            this.btnRemoveCoupon.Click += new System.EventHandler(this.btnRemoveCoupon_Click);
            this.btnRemoveCoupon.MouseHover += new System.EventHandler(this.btnRemoveCoupon_MouseHover);
            // 
            // btnAddCoupon
            // 
            this.btnAddCoupon.Location = new System.Drawing.Point(406, 276);
            this.btnAddCoupon.Name = "btnAddCoupon";
            this.btnAddCoupon.Size = new System.Drawing.Size(96, 64);
            this.btnAddCoupon.TabIndex = 7;
            this.btnAddCoupon.Text = "Add &Coupon";
            this.btnAddCoupon.UseVisualStyleBackColor = true;
            this.btnAddCoupon.Click += new System.EventHandler(this.btnAddCoupon_Click);
            // 
            // dgvResults4
            // 
            this.dgvResults4.AllowUserToAddRows = false;
            this.dgvResults4.AllowUserToDeleteRows = false;
            this.dgvResults4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults4.Location = new System.Drawing.Point(376, 19);
            this.dgvResults4.Name = "dgvResults4";
            this.dgvResults4.ReadOnly = true;
            this.dgvResults4.Size = new System.Drawing.Size(454, 212);
            this.dgvResults4.TabIndex = 0;
            // 
            // tbReports
            // 
            this.tbReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tbReports.Controls.Add(this.lblInfo);
            this.tbReports.Controls.Add(this.mthCalendar);
            this.tbReports.Controls.Add(this.btnView);
            this.tbReports.Controls.Add(this.btnInventoryReport);
            this.tbReports.Controls.Add(this.btnManagers);
            this.tbReports.Controls.Add(this.btnMonthly);
            this.tbReports.Controls.Add(this.btnWeekly);
            this.tbReports.Controls.Add(this.btnDaily);
            this.tbReports.Location = new System.Drawing.Point(4, 27);
            this.tbReports.Name = "tbReports";
            this.tbReports.Padding = new System.Windows.Forms.Padding(3);
            this.tbReports.Size = new System.Drawing.Size(849, 380);
            this.tbReports.TabIndex = 4;
            this.tbReports.Text = "Reports";
            // 
            // btnDaily
            // 
            this.btnDaily.Location = new System.Drawing.Point(36, 287);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(96, 64);
            this.btnDaily.TabIndex = 8;
            this.btnDaily.Text = "&Daily Sales Report";
            this.btnDaily.UseVisualStyleBackColor = true;
            this.btnDaily.Click += new System.EventHandler(this.btnDaily_Click);
            // 
            // btnWeekly
            // 
            this.btnWeekly.Location = new System.Drawing.Point(172, 287);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(96, 64);
            this.btnWeekly.TabIndex = 9;
            this.btnWeekly.Text = "&Weekly Sales Report";
            this.btnWeekly.UseVisualStyleBackColor = true;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // btnMonthly
            // 
            this.btnMonthly.Location = new System.Drawing.Point(308, 287);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(96, 64);
            this.btnMonthly.TabIndex = 10;
            this.btnMonthly.Text = "&Monthly Sales Report";
            this.btnMonthly.UseVisualStyleBackColor = true;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            // 
            // btnManagers
            // 
            this.btnManagers.Location = new System.Drawing.Point(444, 287);
            this.btnManagers.Name = "btnManagers";
            this.btnManagers.Size = new System.Drawing.Size(96, 64);
            this.btnManagers.TabIndex = 11;
            this.btnManagers.Text = "Managers &Info";
            this.btnManagers.UseVisualStyleBackColor = true;
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.Location = new System.Drawing.Point(580, 287);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(96, 64);
            this.btnInventoryReport.TabIndex = 12;
            this.btnInventoryReport.Text = "Inventory &Report";
            this.btnInventoryReport.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(716, 287);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(96, 64);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "&View Reports";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // mthCalendar
            // 
            this.mthCalendar.Location = new System.Drawing.Point(281, 81);
            this.mthCalendar.Name = "mthCalendar";
            this.mthCalendar.TabIndex = 14;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(17, 54);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(358, 18);
            this.lblInfo.TabIndex = 15;
            this.lblInfo.Text = "Please select a start date for Sales Reports:";
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
            this.tbManagerCustomer.ResumeLayout(false);
            this.tbManagerCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults3)).EndInit();
            this.tbCoupons.ResumeLayout(false);
            this.tbCoupons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults4)).EndInit();
            this.tbReports.ResumeLayout(false);
            this.tbReports.PerformLayout();
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
        private System.Windows.Forms.TabPage tbManagerCustomer;
        private System.Windows.Forms.DataGridView dgvResults3;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.Windows.Forms.Button btnDisableCustomer;
        private System.Windows.Forms.Button btnOrderCustomer;
        private System.Windows.Forms.TabPage tbCoupons;
        private System.Windows.Forms.DataGridView dgvResults4;
        private System.Windows.Forms.Button btnAddCoupon;
        private System.Windows.Forms.Button btnRemoveCoupon;
        private System.Windows.Forms.Button btnEditCoupon;
        private System.Windows.Forms.Label lblCouponPercent;
        private System.Windows.Forms.Label lblCouponExpiration;
        private System.Windows.Forms.TextBox tbxCouponPercent;
        private System.Windows.Forms.MonthCalendar mthExpiration;
        private System.Windows.Forms.Label btnCustomerHelp;
        private System.Windows.Forms.Label btnCouponHelp;
        private System.Windows.Forms.HelpProvider hlpManagerCustomer;
        private System.Windows.Forms.HelpProvider hlpManagerCoupon;
        private System.Windows.Forms.TabPage tbReports;
        private System.Windows.Forms.Button btnDaily;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.Button btnManagers;
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.MonthCalendar mthCalendar;
        private System.Windows.Forms.Label lblInfo;
    }
}