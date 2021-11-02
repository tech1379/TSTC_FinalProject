using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace FA21_Final_Project
{
    public partial class frmManager : Form
    {
        int intMouseCount = 0;
        int intMouseCount1 = 0;
        int intMouseCount3 = 0;
        int intMouseCount4 = 0;
        int intMouseCount5 = 0;
        int intMouseCount6 = 0;
        int intMouseCount7 = 0;
        int intMouseCount8 = 0;
        int intMouseCount9 = 0;
        int intMouseCount10 = 0;
        int intMouseCount11 = 0;
        public static bool boolAddManager = false;
        public static bool boolEditManager = false;
        public static bool boolEditCustomer = false;
        public static bool boolCustomerOrder = false;
        public static bool boolHasAccount = false;
        public static string strPersonIDCustomer;
        public static string strPersonID;
        public static int intPersonID = 0;
        public static int intInventoryID = 0;
        public static string strState = "";
        List<clsInventory> lstInventory = new List<clsInventory>();
        List<clsOrders> lstOrders = new List<clsOrders>();
        List<clsOrders> lstOrdersReport = new List<clsOrders>();
        public decimal decSalesTotal = 0;
        public string strStartDate;
        public int intReportNumber;
        public string strReportDate;
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmManager()
        {
            InitializeComponent();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInventory();
                LoadManagers();
                LoadCustomers();
                LoadCoupons();
                tbxCouponPercent.Enabled = true;
                mthExpiration.Enabled = true;
                hlpManagerInventory.HelpNamespace = Application.StartupPath + "\\ManagerInventory.chm";
                hlpManagerManager.HelpNamespace = Application.StartupPath + "\\ManagerManager.chm";
                hlpManagerCustomer.HelpNamespace = Application.StartupPath + "\\Manager_Customer.chm";
                hlpManagerCoupon.HelpNamespace = Application.StartupPath + "\\Manager_Coupon.chm";
                lstOrders = clsSQL.LoadOrders();
                string strSQLReportNumber = "SELECT MAX(SalesReportNumber) FROM tekelle21fa2332.SalesReports;";
                intReportNumber = Convert.ToInt32(clsSQL.DatabaseCommandLogon(strSQLReportNumber));
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults.RowCount == 0)
                {
                    MessageBox.Show("No Inventory Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int intIndex = dgvResults.CurrentRow.Index;
                string strInventoryID = dgvResults.Rows[intIndex].Cells[0].Value.ToString();
                intInventoryID = Convert.ToInt32(strInventoryID);
                int intX = this.Left + (this.Width / 2) - 200;
                int intY = this.Top + (this.Height / 2) - 100;
                this.Hide();
                frmQuantity frmQuantityChange = new frmQuantity();
                frmQuantityChange.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void btnInventory_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount == 0 || intMouseCount == 2)
            {
                MessageBox.Show("Please select the inventory item you would like to change the inventory amount of.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount++;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdd frmAddNewItem = new frmAdd();
            frmAddNewItem.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults.RowCount == 0)
                {
                    MessageBox.Show("No Inventory Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults.CurrentRow.Index;
                string strItemName = dgvResults.Rows[intIndex].Cells[1].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete " + strItemName + " ?", "Inventory Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    string strInventoryID = dgvResults.Rows[intIndex].Cells[0].Value.ToString();
                    intInventoryID = Convert.ToInt32(strInventoryID);
                    string strDeleteInventory = "DELETE FROM tekelle21fa2332.Inventory WHERE InventoryID = " + intInventoryID + ";";
                    clsSQL.UpdateDatabase(strDeleteInventory);
                    MessageBox.Show("Item successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string strSqlInventoryQuery = "SELECT InventoryID, ItemName, ItemDescription, RetailPrice, Cost, Quantity, Discontinued FROM tekelle21fa2332.Inventory;";
                    clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults);
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount1 == 0 || intMouseCount1 == 2)
            {
                MessageBox.Show("Please select the inventory item you would like to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount1++;
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            try
            {
                bool boolNeedRestock = false;
                string strMessage = "";
                lstInventory = clsSQL.ReloadImageList();
                for (int i = 0; i < lstInventory.Count; i++)
                {
                    if (lstInventory[i].intQuantity < 5)
                    {
                        strMessage += lstInventory[i].intInventoryID.ToString() + " " + lstInventory[i].strItemName + " " + lstInventory[i].intQuantity.ToString() + "\n";
                        boolNeedRestock = true;
                    }
                }
                if (boolNeedRestock == true)
                {
                    MessageBox.Show("These items need restocking: \n\n InventoryID\tItemName\tItemQuantity\n" + strMessage, "Inventory Restock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Inventory Quantity is sufficent", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    public void LoadInventory()
        {
            try
            {
                string strSqlInventoryQuery = "SELECT InventoryID, ItemName, ItemDescription, RetailPrice, Cost, Quantity, Discontinued FROM tekelle21fa2332.Inventory;";
                clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadCustomers()
        {
            try
            {
                string strSqlInventoryQuery = "SELECT PersonID, NameFirst, NameLast, Address1, City, ZipCode, State, Email, PhonePrimary, PersonType FROM tekelle21fa2332.Person WHERE PersonType = 'Customer';";
                clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadCoupons()
        {
            try
            {
                string strSqlInventoryQuery = "SELECT CouponID, CouponPercent, ExpirationDate FROM tekelle21fa2332.Coupons;";
                clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadManagers()
        {
            try
            {
                string strSqlInventoryQuery = "SELECT PersonID, NameFirst, NameLast, Address1, City, ZipCode, State, Email, PhonePrimary, PersonType FROM tekelle21fa2332.Person WHERE PersonType = 'Manager';";
                clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddManager_Click(object sender, EventArgs e)
        {
            boolAddManager = true;
            boolEditManager = false;
            boolEditCustomer = false;
            this.Hide();
            frmCreateAcct frmNewPerson = new frmCreateAcct();
            frmNewPerson.ShowDialog();
        }

        private void btnUpdateManager_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults2.RowCount == 0)
                {
                    MessageBox.Show("No Manager Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults2.CurrentRow.Index;
                strPersonID = dgvResults2.Rows[intIndex].Cells[0].Value.ToString();
                strState = dgvResults2.Rows[intIndex].Cells[6].Value.ToString();
                intPersonID = Convert.ToInt32(strPersonID);
                boolAddManager = false;
                boolEditManager = true;
                boolEditCustomer = false;
                this.Hide();
                frmCreateAcct frmNewPerson = new frmCreateAcct();
                frmNewPerson.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateManager_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount3 == 0 || intMouseCount3 == 2)
            {
                MessageBox.Show("Please select the manager you would like to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount3++;
        }

        private void btnRemoveManager_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults2.RowCount == 0)
                {
                    MessageBox.Show("No Manager Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults2.CurrentRow.Index;
                string strManagerName = dgvResults2.Rows[intIndex].Cells[1].Value.ToString() + " " + dgvResults2.Rows[intIndex].Cells[2].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete " + strManagerName + " ?", "Manager Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    string strPersonID = dgvResults2.Rows[intIndex].Cells[0].Value.ToString();
                    intPersonID = Convert.ToInt32(strPersonID);
                    string strDeleteLogon = "DELETE FROM tekelle21fa2332.Logon WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeleteLogon);
                    string strDeletePerson = "DELETE FROM tekelle21fa2332.Person WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeletePerson);
                    
                    MessageBox.Show("Manager successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadManagers();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveManager_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount4 == 0 || intMouseCount4 == 2)
            {
                MessageBox.Show("Please select the manager you would like to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount4++;
        }

        private void btnDisable_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount5 == 0 || intMouseCount5 == 2)
            {
                MessageBox.Show("Please select the manager you would like to disable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount5++;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults2.RowCount == 0)
                {
                    MessageBox.Show("No Manager Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults2.CurrentRow.Index;
                string strManagerName = dgvResults2.Rows[intIndex].Cells[1].Value.ToString() + " " + dgvResults2.Rows[intIndex].Cells[2].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to disable " + strManagerName + " ?", "Disable Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    string strPersonID = dgvResults2.Rows[intIndex].Cells[0].Value.ToString();
                    intPersonID = Convert.ToInt32(strPersonID);
                    string strUpdateLogon = "UPDATE tekelle21fa2332.Logon SET AccountDisabled = 1 WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strUpdateLogon);
                   

                    MessageBox.Show("Manager successfully disabled.", "Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadManagers();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpManagerInventory.HelpNamespace);
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpManagerManager.HelpNamespace);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            boolAddManager = false;
            boolEditManager = false;
            boolEditCustomer = false;
            this.Hide();
            frmCreateAcct frmCreateAcctNew = new frmCreateAcct();
            frmCreateAcctNew.ShowDialog();
        }

        private void btnUpdateCustomer_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount6 == 0 || intMouseCount6 == 2)
            {
                MessageBox.Show("Please select the customer you would like to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount6++;
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults3.RowCount == 0)
                {
                    MessageBox.Show("No Customer Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults3.CurrentRow.Index;
                strPersonID = dgvResults3.Rows[intIndex].Cells[0].Value.ToString();
                strState = dgvResults3.Rows[intIndex].Cells[6].Value.ToString();
                intPersonID = Convert.ToInt32(strPersonID);
                boolAddManager = false;
                boolEditManager = false;
                boolEditCustomer = true;
                this.Hide();
                frmCreateAcct frmNewPerson = new frmCreateAcct();
                frmNewPerson.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveCustomer_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount7 == 0 || intMouseCount7 == 2)
            {
                MessageBox.Show("Please select the customer you would like to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount7++;
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults3.RowCount == 0)
                {
                    MessageBox.Show("No Customer Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults3.CurrentRow.Index;
                string strCustomerName = dgvResults3.Rows[intIndex].Cells[1].Value.ToString() + " " + dgvResults3.Rows[intIndex].Cells[2].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete " + strCustomerName + " ?", "Customer Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    string strPersonID = dgvResults3.Rows[intIndex].Cells[0].Value.ToString();
                    intPersonID = Convert.ToInt32(strPersonID);
                    string strDeleteLogon = "DELETE FROM tekelle21fa2332.Logon WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeleteLogon);
                    string strDeletePerson = "DELETE FROM tekelle21fa2332.Person WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeletePerson);

                    MessageBox.Show("Customer successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisableCustomer_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount8 == 0 || intMouseCount8 == 2)
            {
                MessageBox.Show("Please select the customer you would like to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount8++;
        }

        private void btnDisableCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults3.RowCount == 0)
                {
                    MessageBox.Show("No Customer Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults3.CurrentRow.Index;
                string strCustomerName = dgvResults3.Rows[intIndex].Cells[1].Value.ToString() + " " + dgvResults3.Rows[intIndex].Cells[2].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to disable " + strCustomerName + " ?", "Disable Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    string strPersonID = dgvResults3.Rows[intIndex].Cells[0].Value.ToString();
                    intPersonID = Convert.ToInt32(strPersonID);
                    string strUpdateLogon = "UPDATE tekelle21fa2332.Logon SET AccountDisabled = 1 WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strUpdateLogon);


                    MessageBox.Show("Customer successfully disabled.", "Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrderCustomer_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount9 == 0 || intMouseCount9 == 2)
            {
                MessageBox.Show("Please select the customer you would like to make an order for.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount9++;
        }

        private void btnOrderCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults3.RowCount == 0)
                {
                    MessageBox.Show("No Customer Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults3.CurrentRow.Index;
                strPersonIDCustomer = dgvResults3.Rows[intIndex].Cells[0].Value.ToString();
                boolAddManager = false;
                boolEditManager = false;
                boolEditCustomer = false;
                boolCustomerOrder = true;
                boolHasAccount = true;
                this.Hide();
                frmMain frmMainNew = new frmMain();
                frmMainNew.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxCouponPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnAddCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCouponPercent.Text == "")
                {
                    MessageBox.Show("Coupon Percent cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxCouponPercent.Focus();
                    return;
                }
                decimal decCouponPercent = Convert.ToDecimal(tbxCouponPercent.Text);
                DateTime dtStartDate = mthExpiration.SelectionRange.Start;
                DateTime dtNow = DateTime.Now;
                int intResult = DateTime.Compare(dtStartDate, dtNow);
                if (intResult <= 0)
                {
                    MessageBox.Show("Expiration Date must be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strInsertCoupon = "INSERT INTO tekelle21fa2332.Coupons VALUES(" + decCouponPercent + ", '" + dtStartDate.ToString("yyyy-MM-dd") + "');";
                clsSQL.UpdateDatabase(strInsertCoupon);
                MessageBox.Show("Coupon successfully added", "Coupon Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults4.RowCount == 0)
                {
                    MessageBox.Show("No Coupon Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults4.CurrentRow.Index;
                string strCouponID = dgvResults4.Rows[intIndex].Cells[0].Value.ToString();
                int intCouponID = Convert.ToInt32(strCouponID);
                if (tbxCouponPercent.Text == "")
                {
                    MessageBox.Show("Coupon Percent cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxCouponPercent.Focus();
                    return;
                }
                decimal decCouponPercent = Convert.ToDecimal(tbxCouponPercent.Text);
                DateTime dtStartDate = mthExpiration.SelectionRange.Start;
                DateTime dtNow = DateTime.Now;
                int intResult = DateTime.Compare(dtStartDate, dtNow);
                if (intResult <= 0)
                {
                    MessageBox.Show("Expiration Date must be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strUpdateCoupon = "UPDATE tekelle21fa2332.Coupons SET CouponPercent = " + decCouponPercent + ", ExpirationDate = '" + dtStartDate.ToString("yyyy-MM-dd") + "' WHERE CouponID = " + intCouponID + ";";
                clsSQL.UpdateDatabase(strUpdateCoupon);
                MessageBox.Show("Coupon successfully edited", "Coupon Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCoupons();
                tbxCouponPercent.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCoupon_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount10 == 0 || intMouseCount10 == 2)
            {
                MessageBox.Show("Please select the coupon you would like to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount10++;
        }

        private void btnRemoveCoupon_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount11 == 0 || intMouseCount11 == 2)
            {
                MessageBox.Show("Please select the coupon you would like to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount11++;
        }

        private void btnRemoveCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults4.RowCount == 0)
                {
                    MessageBox.Show("No Coupon Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults4.CurrentRow.Index;
                string strCouponID = dgvResults4.Rows[intIndex].Cells[0].Value.ToString();
                int intCouponID = Convert.ToInt32(strCouponID);
                if (intCouponID == 20003)
                {
                    MessageBox.Show("You can't delete 20003.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete " + strCouponID + " ?", "Coupon Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

              
                    string strDeleteCoupon = "DELETE FROM tekelle21fa2332.Coupons WHERE CouponID = " + intCouponID + ";";
                    clsSQL.UpdateDatabase(strDeleteCoupon);
                    

                    MessageBox.Show("Coupon successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCoupons();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomerHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpManagerCustomer.HelpNamespace);
        }

        private void btnCouponHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpManagerCoupon.HelpNamespace);
        }

        private void btnDaily_Click(object sender, EventArgs e)
        {
            try
            {
                decSalesTotal = 0;
                DateTime dtStartDate = mthCalendar.SelectionRange.Start;
                strStartDate = dtStartDate.ToString();
                strReportDate = dtStartDate.ToString("MMddyyyy");
                intReportNumber++;
                string strUpdateReportNumber = "INSERT INTO tekelle21fa2332.SalesReports VALUES(" + intReportNumber + ");";
                clsSQL.UpdateDatabase(strUpdateReportNumber);
                for (int i = 0; i < lstOrders.Count; i++)
                {
                    if (lstOrders[i].dtOrderDate.ToString() == strStartDate)
                    {
                        lstOrdersReport.Add(lstOrders[i]);
                        decSalesTotal += lstOrders[i].decOrderTotal;
                    }
                }
                //save receipt to my documents
                StringBuilder html = new StringBuilder();
                html = GenerateReport();
                PrintReport(html);
                MessageBox.Show("Sales Report Saved to Documents\\TeksSalesReports.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstOrdersReport.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private StringBuilder GenerateReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();
            try
            {
                css.AppendLine("<style>");
                css.AppendLine("td {padding: 5px; text-align:center; font-weight: bold; text-align: center; font-size: 12px;}");
                css.AppendLine("h1 {color: orange;}");
                css.AppendLine("</style>");

                html.AppendLine("<html>");
                css.AppendLine("<center {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</center>");
                html.AppendLine($"<head style = 'align:center'>{css}<title>{"Receipt"}</title></head>");
                css.AppendLine("<left {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</left>");
                html.Append("<img src= " + clsLogo.strLogo + " style=' align: center; width: 75px; height: 50px;'>");
                html.AppendLine("<body>");

                html.AppendLine($"<h1>{"Sales Report"}</h1>");
                html.Append($"<br>{css}</br>");
                //html.Append($"<p style = 'text-align: left; font-size: 15px'><b>{"Customer: " + strFirstName + " " + strLastName}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 15px'><b>{"Order Number: " + strMaxOrderID}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 10px'><b>{"Phone Number: " + strPhoneNumber}</b></p>");
                html.AppendLine("<table>");
       
                html.AppendLine("<tr><td>OrderID</td><td>PersonID</td><td>Date</td></td><td>OrderTotal</td></td><td>CouponID</td></tr>");
                html.AppendLine("<tr><td colspan=5><hr /></td></tr>");
                for (int i = 0; i < lstOrdersReport.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{lstOrdersReport[i].intOrderID}</td>");
                    html.Append($"<td>{lstOrdersReport[i].intPersonID}</td>");
                    html.Append($"<td>{lstOrdersReport[i].dtOrderDate}</td>");
                    html.Append($"<td>{lstOrdersReport[i].decOrderTotal}</td>");
                    html.Append($"<td>{lstOrdersReport[i].intCouponID}</td>");
                    html.Append("</tr>");
                    html.AppendLine("<tr><td colspan=6><hr /></td></tr>");
                }
                html.AppendLine("</table>");
                html.Append($"<br></br><br></br>");
                html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 25px '><b>{"Sales Total: " + decSalesTotal.ToString("C2")}</b></p>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 15px '><b>{"Discount Percent: " + decDiscountPercent.ToString("N3")}</b></p>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 15px '><b>{"Discount: " + decDiscount.ToString("C2")}</b></p>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 15px '><b>{"SubTotal After Discount: " + decSubTotalDiscount.ToString("C2")}</b></p>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 15px '><b>{"Taxes: " + decTaxes.ToString("C2")}</b></p>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 20px ' ><b>{"Total: " + decTotal.ToString("C2")}</b></p>");
                html.Append($"<div><button onClick='window.print()'> {"Print this page"}</ button ></ div >");
                html.AppendLine("</body></html>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return html; // The returned value has all the HTML and CSS code to represent a webpage
        }
        private void PrintReport(StringBuilder html)
        {
            // Write (and overwrite) to the hard drive using the same filename of "Report.html"
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeksSalesReports"));
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
               // MessageBox.Show(path);
                using (StreamWriter writer = new StreamWriter(path + "\\TeksSalesReports\\" + intReportNumber.ToString() + "_" + strReportDate + "SalesReport.html"))
                {
                    writer.WriteLine(html);
                }
                //System.Diagnostics.Process.Start(@path + "\\TeksSalesReports\\" + strReportDate + "SalesReport.html"); //Open the report in the default web browser

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            try
            {
                decSalesTotal = 0;
                DateTime dtStartDate = mthCalendar.SelectionRange.Start;
                DateTime dtEndDate = dtStartDate.AddDays(7.00);
                strStartDate = dtStartDate.ToString();
                strReportDate = dtStartDate.ToString("MMddyyyy");
                intReportNumber++;
                string strUpdateReportNumber = "INSERT INTO tekelle21fa2332.SalesReports VALUES(" + intReportNumber + ");";
                clsSQL.UpdateDatabase(strUpdateReportNumber);
                for (int i = 0; i < lstOrders.Count; i++)
                {
                    if (lstOrders[i].dtOrderDate >= dtStartDate && lstOrders[i].dtOrderDate <= dtEndDate)
                    {
                        lstOrdersReport.Add(lstOrders[i]);
                        decSalesTotal += lstOrders[i].decOrderTotal;
                    }
                }
                //save receipt to my documents
                StringBuilder html = new StringBuilder();
                html = GenerateReport();
                PrintReport(html);
                MessageBox.Show("Sales Report Saved to Documents\\TeksSalesReports.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                decSalesTotal = 0;
                DateTime dtStartDate = mthCalendar.SelectionRange.Start;
                DateTime dtEndDate = dtStartDate.AddDays(30.00);
                strStartDate = dtStartDate.ToString();
                strReportDate = dtStartDate.ToString("MMddyyyy");
                intReportNumber++;
                string strUpdateReportNumber = "INSERT INTO tekelle21fa2332.SalesReports VALUES(" + intReportNumber + ");";
                clsSQL.UpdateDatabase(strUpdateReportNumber);
                for (int i = 0; i < lstOrders.Count; i++)
                {
                    if (lstOrders[i].dtOrderDate >= dtStartDate && lstOrders[i].dtOrderDate <= dtEndDate)
                    {
                        lstOrdersReport.Add(lstOrders[i]);
                        decSalesTotal += lstOrders[i].decOrderTotal;
                    }
                }
                //save receipt to my documents
                StringBuilder html = new StringBuilder();
                html = GenerateReport();
                PrintReport(html);
                MessageBox.Show("Sales Report Saved to Documents\\TeksSalesReports.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog1.InitialDirectory = @path + "\\TeksSalesReports\\";
                openFileDialog1.DefaultExt = "html";
                openFileDialog1.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var onlyFileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                    System.Diagnostics.Process.Start(@path + "\\TeksSalesReports\\" + onlyFileName); //Open the report in the default web browser

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
