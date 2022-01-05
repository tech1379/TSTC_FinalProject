//******************************************
//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my manager screen
//******************************************
//***
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
        int intMouseCount12 = 0;
        int intMouseCount13 = 0;
        public static bool boolAddManager = false;
        public static bool boolEditManager = false;
        public static bool boolEditCustomer = false;
        public static bool boolCustomerOrder = false;
        public static bool boolHasAccount = false;
        public static bool boolEditInventory = false;
        public static bool boolAddCustomer = false;
        public static string strPersonIDCustomer;
        public static string strPersonID;
        public static int intPersonID = 0;
        public static int intInventoryID = 0;
        public static string strState = "";
        public static string strRestock;
        List<clsInventory> lstInventory = new List<clsInventory>(clsSQL.ReloadImageList());
        List<clsInventory> lstInventoryRestock = new List<clsInventory>();
        List<clsOrders> lstOrders = new List<clsOrders>();
        List<clsOrders> lstOrdersReport = new List<clsOrders>();
        List<clsPerson> lstManagerReport = new List<clsPerson>();
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
                helpManagerReport.HelpNamespace = Application.StartupPath + "\\Manager_Reports.chm";
                lstOrders = clsSQL.LoadOrders();
                string strSQLReportNumber = "SELECT MAX(SalesReportNumber) FROM SalesReports;";
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
                intMouseCount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void btnInventory_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount == 0)
            {
                MessageBox.Show("Please select the inventory item you would like to change the inventory amount of.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount++;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            boolEditInventory = false;
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
                    string strDeleteInventory = "DELETE FROM Inventory WHERE InventoryID = " + intInventoryID + ";";
                    clsSQL.UpdateDatabase(strDeleteInventory);
                    MessageBox.Show("Item successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string strSqlInventoryQuery = "SELECT InventoryID, ItemName, ItemDescription, RetailPrice, Cost, Quantity, Discontinued FROM Inventory;";
                    clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults);
                    intMouseCount1 = 0;
                }
                else
                {
                    intMouseCount1 = 0;
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
            if (intMouseCount1 == 0)
            {
                MessageBox.Show("Please select the inventory item you would like to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount1++;
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            try
            {
                //check restock levels, check threshold from db, then check levels, it below save ones below to report and output the ones to screen
                string strQueryRestock = "SELECT RestockLevel FROM Restock ORDER BY RestockID DESC;";
                strRestock = clsSQL.DatabaseCommandLogon(strQueryRestock);
                int intRestock = Convert.ToInt32(strRestock);
                bool boolNeedRestock = false;
                string strMessage = "";
                //lstInventory = clsSQL.ReloadImageList();
                for (int i = 0; i < lstInventory.Count; i++)
                {
                    if (lstInventory[i].intQuantity < intRestock)
                    {
                        strMessage += lstInventory[i].intInventoryID.ToString() + " " + lstInventory[i].strItemName + " " + lstInventory[i].intQuantity.ToString() + "\n";
                        boolNeedRestock = true;
                        lstInventoryRestock.Add(lstInventory[i]);
                    }
                }
                if (boolNeedRestock == true)
                {
                    MessageBox.Show("These items need restocking: \n\n InventoryID\tItemName\tItemQuantity\n" + strMessage, "Inventory Restock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StringBuilder html = new StringBuilder();
                    html = GenerateReportInventoryRestock();
                    PrintReportInventoryRestock(html);
                    MessageBox.Show("Inventory Report Saved to Documents\\TeksManagersReports.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string strSqlInventoryQuery = "SELECT InventoryID AS 'Inventory ID', ItemName AS 'Item Name', ItemDescription AS 'Item Description', RetailPrice AS 'Retail Price', Cost, Quantity, Discontinued FROM Inventory;";
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
                string strSqlInventoryQuery = "SELECT PersonID AS 'Person ID', NameFirst AS 'First Name', NameLast AS 'Last Name', Address1 AS 'Address 1', Address2 AS 'Address 2', Address3 AS 'Address 3', City, ZipCode AS 'Zip Code', State, Email, PhonePrimary AS 'Phone Primary', PersonType AS 'Person Type' FROM Person WHERE PersonType = 'Customer';";
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
                string strSqlInventoryQuery = "SELECT CouponID AS 'Coupon ID', FORMAT(CouponPercent,'#,##0.0%') AS 'Coupon Percent', ExpirationDate AS 'Expiration Date' FROM Coupons;";
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
                string strSqlInventoryQuery = "SELECT PersonID AS 'Person ID', NameFirst AS 'First Name', NameLast AS 'Last Name', Address1 AS 'Address 1', Address2 AS 'Address 2', Address3 AS 'Address 3', City, ZipCode AS 'Zip Code', State, Email, PhonePrimary AS 'Phone Primary', PersonType AS 'Person Type' FROM Person WHERE PersonType = 'Manager';";
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
                intMouseCount3 = 0;
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
            if (intMouseCount3 == 0)
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
                    string strDeleteLogon = "DELETE FROM Logon WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeleteLogon);
                    string strDeletePerson = "DELETE FROM Person WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeletePerson);
                    
                    MessageBox.Show("Manager successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadManagers();
                    intMouseCount4 = 0;
                }
                else
                {
                    intMouseCount4 = 0;
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
            if (intMouseCount4 == 0)
            {
                MessageBox.Show("Please select the manager you would like to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount4++;
        }

        private void btnDisable_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount5 == 0)
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
                    string strUpdateLogon = "UPDATE Logon SET AccountDisabled = 1 WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strUpdateLogon);
                   

                    MessageBox.Show("Manager successfully disabled.", "Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadManagers();
                    intMouseCount5 = 0;
                }
                else
                {
                    intMouseCount5 = 0;
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
            boolAddCustomer = true;
            this.Hide();
            frmCreateAcct frmCreateAcctNew = new frmCreateAcct();
            frmCreateAcctNew.ShowDialog();
        }

        private void btnUpdateCustomer_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount6 == 0)
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
                intMouseCount6 = 0;
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
            if (intMouseCount7 == 0)
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
                    string strDeleteLogon = "DELETE FROM Logon WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeleteLogon);
                    string strDeletePerson = "DELETE FROM Person WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strDeletePerson);

                    MessageBox.Show("Customer successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                    intMouseCount7 = 0;
                }
                else
                {
                    intMouseCount7 = 0;
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
            if (intMouseCount8 == 0)
            {
                MessageBox.Show("Please select the customer you would like to disable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string strUpdateLogon = "UPDATE Logon SET AccountDisabled = 1 WHERE PersonID = " + intPersonID + ";";
                    clsSQL.UpdateDatabase(strUpdateLogon);


                    MessageBox.Show("Customer successfully disabled.", "Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                    intMouseCount8 = 0;
                }
                else
                {
                    intMouseCount8 = 0;
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
            if (intMouseCount9 == 0)
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
                strPersonID = frmLogIn.strPersonID;
                intMouseCount9 = 0;
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
                string strInsertCoupon = "INSERT INTO Coupons VALUES(" + decCouponPercent + ", '" + dtStartDate.ToString("yyyy-MM-dd") + "');";
                clsSQL.UpdateDatabase(strInsertCoupon);
                MessageBox.Show("Coupon successfully added", "Coupon Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCoupons();
               
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
                string strUpdateCoupon = "UPDATE Coupons SET CouponPercent = " + decCouponPercent + ", ExpirationDate = '" + dtStartDate.ToString("yyyy-MM-dd") + "' WHERE CouponID = " + intCouponID + ";";
                clsSQL.UpdateDatabase(strUpdateCoupon);
                MessageBox.Show("Coupon successfully edited", "Coupon Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCoupons();
                intMouseCount10 = 0;
                tbxCouponPercent.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCoupon_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount10 == 0)
            {
                MessageBox.Show("Please select the coupon you would like to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount10++;
        }

        private void btnRemoveCoupon_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount11 == 0)
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

                    string strDeleteCoupon = "DELETE FROM Coupons WHERE CouponID = " + intCouponID + ";";
                    clsSQL.UpdateDatabase(strDeleteCoupon);

                    

                    MessageBox.Show("Coupon successfully deleted.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCoupons();
                    intMouseCount11 = 0;
                }
                else
                {
                    intMouseCount11 = 0;
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
                string strSQLReportNumber = "SELECT MAX(SalesReportNumber) FROM SalesReports;";
                intReportNumber = Convert.ToInt32(clsSQL.DatabaseCommandLogon(strSQLReportNumber));
                decSalesTotal = 0;
                DateTime dtStartDate = mthCalendar.SelectionRange.Start;
                strStartDate = dtStartDate.ToString();
                strReportDate = dtStartDate.ToString("MMddyyyy");
                intReportNumber++;
                string strUpdateReportNumber = "INSERT INTO SalesReports VALUES(" + intReportNumber + ");";
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
                html.AppendLine($"<head style = 'align:center'>{css}<title>{"Sales Report"}</title></head>");
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
                string strSQLReportNumber = "SELECT MAX(SalesReportNumber) FROM SalesReports;";
                intReportNumber = Convert.ToInt32(clsSQL.DatabaseCommandLogon(strSQLReportNumber));
                decSalesTotal = 0;
                DateTime dtStartDate = mthCalendar.SelectionRange.Start;
                DateTime dtEndDate = dtStartDate.AddDays(7.00);
                strStartDate = dtStartDate.ToString();
                strReportDate = dtStartDate.ToString("MMddyyyy");
                intReportNumber++;
                string strUpdateReportNumber = "INSERT INTO SalesReports VALUES(" + intReportNumber + ");";
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
                string strSQLReportNumber = "SELECT MAX(SalesReportNumber) FROM SalesReports;";
                intReportNumber = Convert.ToInt32(clsSQL.DatabaseCommandLogon(strSQLReportNumber));
                decSalesTotal = 0;
                DateTime dtStartDate = mthCalendar.SelectionRange.Start;
                int month = dtStartDate.Month;
                int day = 1;
                int year = dtStartDate.Year;
                dtStartDate = new DateTime(year, month, day);
                DateTime dtEndDate;
                if (month == 11 || month == 4 || month == 9 || month == 6)
                {
                    dtEndDate = dtStartDate.AddDays(30.00);
                }
                else if(month == 2)
                {
                    dtEndDate = dtStartDate.AddDays(28.00);
                }
                else
                {
                    dtEndDate = dtStartDate.AddDays(31.00);
                }
                strStartDate = dtStartDate.ToString();
                strReportDate = dtStartDate.ToString("MMddyyyy");
                intReportNumber++;
                string strUpdateReportNumber = "INSERT INTO SalesReports VALUES(" + intReportNumber + ");";
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
                openFileDialog1.InitialDirectory = @path;
                openFileDialog1.DefaultExt = "html";
                openFileDialog1.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //path = Environment.GetFolderPath(openFileDialog1.InitialDirectory);
                    var onlyFileName = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    System.Diagnostics.Process.Start(onlyFileName); //Open the report in the default web browser

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
                boolEditInventory = true;
                intMouseCount12 = 0;
                this.Hide();
                frmAdd frmAddNewItem = new frmAdd();
                frmAddNewItem.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount12 == 0)
            {
                MessageBox.Show("Please select the item you would like to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount12++;
        }

        private void btnManagers_Click(object sender, EventArgs e)
        {
            try
            {
                lstManagerReport = clsSQL.LoadManagerSalary();
                StringBuilder html = new StringBuilder();
                html = GenerateReportManagers();
                PrintReportManagers(html);
                MessageBox.Show("Sales Report Saved to Documents\\TeksManagersReports.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private StringBuilder GenerateReportManagers()
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
                html.AppendLine($"<head style = 'align:center'>{css}<title>{"Manager Report"}</title></head>");
                css.AppendLine("<left {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</left>");
                html.Append("<img src= " + clsLogo.strLogo + " style=' align: center; width: 75px; height: 50px;'>");
                html.AppendLine("<body>");

                html.AppendLine($"<h1>{"Managers Report"}</h1>");
                html.Append($"<br>{css}</br>");
                //html.Append($"<p style = 'text-align: left; font-size: 15px'><b>{"Customer: " + strFirstName + " " + strLastName}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 15px'><b>{"Order Number: " + strMaxOrderID}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 10px'><b>{"Phone Number: " + strPhoneNumber}</b></p>");
                html.AppendLine("<table>");

                html.AppendLine("<tr><td>First Name</td><td>Last Name</td></td><td>Phone</td></td><td>Email</td><td>Position</td><td>Salary</td></tr>");
                html.AppendLine("<tr><td colspan=6><hr /></td></tr>");
                for (int i = 0; i < lstManagerReport.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{lstManagerReport[i].strPersonFirstName}</td>");
                    html.Append($"<td>{lstManagerReport[i].strPersonLastName}</td>");
                    html.Append($"<td>{lstManagerReport[i].strPhoneNumber}</td>");
                    html.Append($"<td>{lstManagerReport[i].strEmail}</td>");
                    html.Append($"<td>{lstManagerReport[i].strPosition}</td>");
                    html.Append($"<td>{lstManagerReport[i].decSalary.ToString("C2")}</td>");
                    html.Append("</tr>");
                    html.AppendLine("<tr><td colspan=7><hr /></td></tr>");
                }
                html.AppendLine("</table>");
                html.Append($"<br></br><br></br>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 25px '><b>{"Sales Total: " + decSalesTotal.ToString("C2")}</b></p>");
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
        private void PrintReportManagers(StringBuilder html)
        {
            // Write (and overwrite) to the hard drive using the same filename of "Report.html"
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeksManagersReports"));
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
                // MessageBox.Show(path);
                string strDate = DateTime.Now.ToString("MMddyyyy");
                using (StreamWriter writer = new StreamWriter(path + "\\TeksManagersReports\\" + strDate + "ManagerReport.html"))
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

        private void btnEditRestock_Click(object sender, EventArgs e)
        {
            intMouseCount13 = 0;
            frmRestock frmRestockNew = new frmRestock();
            frmRestockNew.ShowDialog();
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            try
            {
                string strQueryRestock = "SELECT RestockLevel FROM Restock ORDER BY RestockID DESC;";
                strRestock = clsSQL.DatabaseCommandLogon(strQueryRestock);
                StringBuilder html = new StringBuilder();
                html = GenerateReportInventory();
                PrintReportInventory(html);
                MessageBox.Show("Inventory Report Saved to Documents\\TeksManagersReports.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private StringBuilder GenerateReportInventory()
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
                html.AppendLine($"<head style = 'align:center'>{css}<title>{"Inventory Report"}</title></head>");
                css.AppendLine("<left {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</left>");
                html.Append("<img src= " + clsLogo.strLogo + " style=' align: center; width: 75px; height: 50px;'>");
                html.AppendLine("<body>");

                html.AppendLine($"<h1>{"Inventory Report"}</h1>");
                html.Append($"<br>{css}</br>");

                html.Append($"<p style = 'text-align: left; font-size: 25px'><b>{"Restock Threshold: " + strRestock}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 15px'><b>{"Order Number: " + strMaxOrderID}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 10px'><b>{"Phone Number: " + strPhoneNumber}</b></p>");
                html.AppendLine("<table>");

                html.AppendLine("<tr><td>Inventory ID</td><td>Inventory Name</td></td><td>Cost</td></td><td>Price</td><td>Quantity</td></tr>");
                html.AppendLine("<tr><td colspan=5><hr /></td></tr>");
                for (int i = 0; i < lstInventory.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{lstInventory[i].intInventoryID.ToString()}</td>");
                    html.Append($"<td>{lstInventory[i].strItemName}</td>");
                    html.Append($"<td>{lstInventory[i].decCost.ToString("C2")}</td>");
                    html.Append($"<td>{lstInventory[i].decRetailPrice.ToString("C2")}</td>");
                    html.Append($"<td>{lstInventory[i].intQuantity.ToString()}</td>");
                    html.Append("</tr>");
                    html.AppendLine("<tr><td colspan=6><hr /></td></tr>");
                }
                html.AppendLine("</table>");
                html.Append($"<br></br><br></br>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 25px '><b>{"Sales Total: " + decSalesTotal.ToString("C2")}</b></p>");
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
        private void PrintReportInventory(StringBuilder html)
        {
            // Write (and overwrite) to the hard drive using the same filename of "Report.html"
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeksManagersReports"));
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
                // MessageBox.Show(path);
                string strDate = DateTime.Now.ToString("MMddyyyy");
                using (StreamWriter writer = new StreamWriter(path + "\\TeksManagersReports\\" + strDate + "InventoryReport.html"))
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

        private void lblHelpReports_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpManagerReport.HelpNamespace);
        }

        private void btnEditRestock_MouseHover(object sender, EventArgs e)
        {
            if (intMouseCount13 == 0)
            {
                MessageBox.Show("You can change restock threshold here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            intMouseCount13++;
        }
        private StringBuilder GenerateReportInventoryRestock()
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
                html.AppendLine($"<head style = 'align:center'>{css}<title>{"Inventory Restock Report"}</title></head>");
                css.AppendLine("<left {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</left>");
                html.Append("<img src= " + clsLogo.strLogo + " style=' align: center; width: 75px; height: 50px;'>");
                html.AppendLine("<body>");

                html.AppendLine($"<h1>{"Inventory Restock Report"}</h1>");
                html.Append($"<br>{css}</br>");

                html.Append($"<p style = 'text-align: left; font-size: 25px'><b>{"Restock Threshold: " + strRestock}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 15px'><b>{"Order Number: " + strMaxOrderID}</b></p>");
                //html.Append($"<p style = 'text-align: left; font-size: 10px'><b>{"Phone Number: " + strPhoneNumber}</b></p>");
                html.AppendLine("<table>");

                html.AppendLine("<tr><td>Inventory ID</td><td>Inventory Name</td></td><td>Cost</td></td><td>Price</td><td>Quantity</td></tr>");
                html.AppendLine("<tr><td colspan=5><hr /></td></tr>");
                for (int i = 0; i < lstInventoryRestock.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{lstInventoryRestock[i].intInventoryID.ToString()}</td>");
                    html.Append($"<td>{lstInventoryRestock[i].strItemName}</td>");
                    html.Append($"<td>{lstInventoryRestock[i].decCost.ToString("C2")}</td>");
                    html.Append($"<td>{lstInventoryRestock[i].decRetailPrice.ToString("C2")}</td>");
                    html.Append($"<td>{lstInventoryRestock[i].intQuantity.ToString()}</td>");
                    html.Append("</tr>");
                    html.AppendLine("<tr><td colspan=6><hr /></td></tr>");
                }
                html.AppendLine("</table>");
                html.Append($"<br></br><br></br>");
                //html.Append($"<p style = 'text-align:right; text-indent: 0px; font-size: 25px '><b>{"Sales Total: " + decSalesTotal.ToString("C2")}</b></p>");
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
        private void PrintReportInventoryRestock(StringBuilder html)
        {
            // Write (and overwrite) to the hard drive using the same filename of "Report.html"
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeksManagersReports"));
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
                // MessageBox.Show(path);
                string strDate = DateTime.Now.ToString("MMddyyyy");
                using (StreamWriter writer = new StreamWriter(path + "\\TeksManagersReports\\" + strDate + "InventoryRestockReport.html"))
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

        private void frmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Application.OpenForms["frmLogIn"].Hide();
            frmLogIn frmLogInNew = new frmLogIn();
            frmLogInNew.ShowDialog();
        }
    }
}
