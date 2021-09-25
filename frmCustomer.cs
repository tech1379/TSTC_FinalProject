//******************************************
//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my customer screen
//******************************************
//******************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FA21_Final_Project
{
    public partial class frmCustomer : Form
    {
        public static string strPersonID = frmMain.strPersonID;
        private int intSelectedImageID = 0;
        private int intCurrent = 0;
        public int intCouponCode = 0;
        public static decimal decSubTotal = 0;
        public static decimal decDiscountPercent;
        public static decimal decDiscount;
        public static decimal decSubTotalDiscount;
        public static decimal decTaxes = 0;
        public static decimal decTotal = 0;
        public bool boolHasAccount = frmMain.boolHasAccount;
        List<clsInventory> lstInventory = new List<clsInventory>();
        List<clsCoupon> lstCoupon = new List<clsCoupon>();
        List<string> lstShoppingCartName = new List<string>();
        List<int> lstIntCurrentIndex = new List<int>();
        List<int> lstShoppingCartInventoryID = new List<int>();
        List<decimal> lstShoppingCartCost = new List<decimal>();
        List<int> lstShoppingCartQuantity = new List<int>();
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
            "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                //load db information and display on form
                lstInventory.Clear();
                lstInventory = clsSQL.ReloadImageList();
                lstCoupon = clsSQL.LoadCoupons();

                for (int i = 0; i < lstCoupon.Count; i++)
                {
                    cbxCouponCode.Items.Add(lstCoupon[i].intCouponID);
                }
                if (lstInventory.Count > 0)
                {
                    using (MemoryStream ms = new MemoryStream(lstInventory[0].bytImage))
                    {
                        Image image = Image.FromStream(ms);
                        pbxImage.Image = image;
                    }
                    intSelectedImageID = lstInventory[0].intInventoryID;
                    lblName.Text = lstInventory[0].strItemName;
                    lblDescription.Text = lstInventory[0].strItemDescription;
                    lblCost.Text = "$" + lstInventory[0].decRetailPrice.ToString();
                    lblQuantity.Text = lstInventory[0].intQuantity.ToString();
                    for (int i = 1; i <= lstInventory[0].intQuantity; i++)
                    {
                        cbxQuantity.Items.Add(i);
                    }
                }
                if (!boolHasAccount)
                {
                    //set up browse inventory form
                    this.tbCustomer.TabPages.Remove(tbQuailHunts);
                    this.tbCustomer.TabPages.Remove(tbTraining);
                    this.tbCustomer.TabPages.Remove(tbShoppingCart);
                    btnAdd.Enabled = false;
                    btnAdd.Visible = false;
                }

                //set dgv for Receipt
                dgvResults.Columns.Add("Name", "Name");
                dgvResults.Columns.Add("Quantity", "Quantity");
                dgvResults.Columns.Add("Line Item Total", "Line Item Total");
                //dgvResults.Columns[0].Width = 275;
                //dgvResults.Columns[1].Width = 100;
                //dgvResults.Columns[2].Width = 200;
                //lblCustomer.BorderStyle = BorderStyle.None;

                //get customer name
                string strQueryFirstName = "SELECT NameFirst FROM tekelle21fa2332.Person WHERE PersonID = " + Convert.ToInt32(strPersonID) + ";";
                string strQueryLastName = "SELECT NameLast FROM tekelle21fa2332.Person WHERE PersonID = " + Convert.ToInt32(strPersonID) + ";";
                string strFirstName = clsSQL.DatabaseCommandLogon(strQueryFirstName);
                string strLastName = clsSQL.DatabaseCommandLogon(strQueryLastName);
                lblCustomer.Text = strFirstName + " " + strLastName;

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstInventory.Count == 0)
                {
                    return;
                }
                intCurrent++;
                LoadNext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstInventory.Count == 0)
                {
                    return;
                }
                intCurrent--;
                LoadPrevious();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadNext()
        {
            try
            {

                if (intCurrent >= lstInventory.Count)
                {
                    intCurrent = 0;
                }

                using (MemoryStream ms = new MemoryStream(lstInventory[intCurrent].bytImage))
                {
                    Image image = Image.FromStream(ms);
                    pbxImage.Image = image;
                }

                intSelectedImageID = lstInventory[intCurrent].intInventoryID;
                lblName.Text = lstInventory[intCurrent].strItemName;
                lblDescription.Text = lstInventory[intCurrent].strItemDescription;
                lblCost.Text = "$" + lstInventory[intCurrent].decRetailPrice.ToString();
                lblQuantity.Text = lstInventory[intCurrent].intQuantity.ToString();
                for (int i = 1; i <= lstInventory[intCurrent].intQuantity; i++)
                {
                    cbxQuantity.Items.Add(i);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadPrevious()
        {
            try
            {
                if (intCurrent < 0 & lstInventory.Count > 0)
                {
                    intCurrent = lstInventory.Count - 1;
                }

                using (MemoryStream ms = new MemoryStream(lstInventory[intCurrent].bytImage))
                {
                    Image image = Image.FromStream(ms);
                    pbxImage.Image = image;
                }

                intSelectedImageID = lstInventory[intCurrent].intInventoryID;
                lblName.Text = lstInventory[intCurrent].strItemName;
                lblDescription.Text = lstInventory[intCurrent].strItemDescription;
                lblCost.Text = "$" + lstInventory[intCurrent].decRetailPrice.ToString();
                lblQuantity.Text = lstInventory[intCurrent].intQuantity.ToString();
                for (int i = 1; i <= lstInventory[intCurrent].intQuantity; i++)
                {
                    cbxQuantity.Items.Add(i);
                }
                
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add items selected to list to add to cart, adjust quantity for application only
            try
            {
                if(cbxQuantity.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lstShoppingCartName.Add(lstInventory[intCurrent].strItemName);
                lstShoppingCartCost.Add(lstInventory[intCurrent].decRetailPrice * Convert.ToInt32(cbxQuantity.SelectedItem));
                lstIntCurrentIndex.Add(intCurrent);
                lstShoppingCartQuantity.Add(Convert.ToInt32(cbxQuantity.SelectedItem));
                lstShoppingCartInventoryID.Add(lstInventory[intCurrent].intInventoryID);
                lstInventory[intCurrent].intQuantity -= Convert.ToInt32(cbxQuantity.SelectedItem);
                lblQuantity.Text = lstInventory[intCurrent].intQuantity.ToString();
                LoadDGV();
                FillInformation();
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDGV()
        {
            try
            {
                //load DGV
                //fill the datagrid view with values from Shop form
                for (int i = 0; i < lstShoppingCartName.Count(); i++)
                {
                    dgvResults.Rows.Add();
                    dgvResults[0, i].Value = lstShoppingCartName[i];
                    dgvResults[1, i].Value = lstShoppingCartQuantity[i];
                    dgvResults[2, i].Value = lstShoppingCartCost[i];
                    //decSubTotal += (lstShoppingCartCost[i]);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillInformation()
        {
            //fills the information for the textboxes
            try
            {
                decSubTotal = 0;
                if (cbxCouponCode.SelectedIndex == -1)
                {
                    decDiscountPercent = 0.00M;
                }
                else
                {
                    decDiscountPercent = lstCoupon[cbxCouponCode.SelectedIndex].decCouponPercent;
                }
                for (int i = 0; i < lstShoppingCartCost.Count; i++)
                {
                    decSubTotal += lstShoppingCartCost[i];
                }
                lblSubTotal.Text = decSubTotal.ToString("C2");
                lblDiscPercent.Text = decDiscountPercent.ToString("N2");
                decDiscount = decSubTotal * decDiscountPercent;
                lblDiscount.Text = decDiscount.ToString("C2");
                decSubTotalDiscount = decSubTotal - decDiscount;
                lblSubTotalDisc.Text = decSubTotalDiscount.ToString("C2");
                decTaxes = (decSubTotalDiscount * (decimal)(.0825));
                lblTaxes.Text = decTaxes.ToString("C2");
                decTotal = decSubTotalDiscount + decTaxes;
                lblTotal.Text = decTotal.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int GetCouponCode()
        {
            try
            {
                if (cbxCouponCode.SelectedIndex == -1)
                {
                    intCouponCode = 20003;
                }
                else
                {
                    intCouponCode = Convert.ToInt32(cbxCouponCode.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return intCouponCode;
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            //get credit card information check and save orders, and order items to db and update quantity in inventory
            try
            {
                CreditCardUpdate();
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                GetCouponCode();
                string strInsertOrder = "INSERT INTO tekelle21fa2332.Orders VALUES (" + Convert.ToInt32(strPersonID) +
                    ", '" + date + "', " + decTotal + ", " + intCouponCode + ");";
                clsSQL.UpdateDatabase(strInsertOrder);
                string strMaxOrderIDQuery = "SELECT MAX(OrderID) FROM tekelle21fa2332.Orders;";
                string strMaxOrderID = clsSQL.DatabaseCommandLogon(strMaxOrderIDQuery);
                for (int i = 0; i < lstShoppingCartInventoryID.Count; i++)
                {
                    string strInsertOrderItems = "INSERT INTO tekelle21fa2332.OrderItems VALUES (" + lstShoppingCartInventoryID[i] + ", " + Convert.ToInt32(strMaxOrderID) +
                        ", " + lstShoppingCartQuantity[i] + ", " + lstShoppingCartCost[i] + ");";
                    clsSQL.UpdateDatabase(strInsertOrderItems);
                    string strInsertQuantity = "UPDATE tekelle21fa2332.Inventory SET Quantity = Quantity - " + lstShoppingCartQuantity[i] + " WHERE InventoryID = " + lstShoppingCartInventoryID[i] + ";";
                    clsSQL.UpdateDatabase(strInsertQuantity);
                }
                MessageBox.Show("Order Saved.", "Information Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ExpirationDatePast(string strExpirationDate)
        { //check to see if credit card expiration date is past
            bool boolPastExpiration = true;
            try
            {
                int intMonth = DateTime.Now.Month;
                int intYear = DateTime.Now.Year;
                string strMonth = strExpirationDate.Substring(0, 2);
                string strYear = strExpirationDate.Substring(3);
                int intMonthExp = Convert.ToInt32(strMonth);
                int intYearExp = Convert.ToInt32(strYear) + 2000;
                if (intYearExp <= intYear)
                {
                    if (intYearExp < intYear)
                    {
                        boolPastExpiration = true;
                    }
                    else if(intYearExp == intYear)
                    {
                        if(intMonthExp < intMonth)
                        {
                            boolPastExpiration = true;
                        }
                        else
                        {
                            boolPastExpiration = false;
                        }
                    }
                }
                else
                {
                    boolPastExpiration = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolPastExpiration;
        }
        private void btnCart_Click(object sender, EventArgs e)
        {
            //move to shopping cart
            tbCustomer.SelectedIndex = 3;
        }

        private void tbxCreditCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((int)e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxExpiration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == 8)
            { //acceptable keystrokes
                e.Handled = false;
            }
            else if ((int)e.KeyChar == '/')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbxCouponCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change coupon discount refill information
            try
            {
                FillInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
         }
        public void CreditCardUpdate()
        {
            //validate credit card and expiration format and update database
            try
            {
                string strCreditCard = tbxCreditCard.Text;
                string strExpiration = tbxExpiration.Text;
                if (strCreditCard == "")
                {
                    MessageBox.Show("Credit Card cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidCreditCard(strCreditCard))
                {
                    MessageBox.Show("Credit Card Format 1234-5678-1234-5678.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (strExpiration == "")
                {
                    MessageBox.Show("Expiration Date cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsValidation.ValidExpiration(strExpiration))
                {
                    MessageBox.Show("Expiration Date Format MM/YY.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ExpirationDatePast(strExpiration))
                {
                    MessageBox.Show("Card is Expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strInsertCreditCardQuery = "INSERT INTO tekelle21fa2332.CreditCard VALUES (" + Convert.ToInt32(strPersonID) + ", '" + strCreditCard +
                    "', '" + strExpiration + "');";
                clsSQL.UpdateDatabase(strInsertCreditCardQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {//check to see if dgv is empty
                if (dgvResults.RowCount == 0)
                {
                    MessageBox.Show("Nothing to Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int intIndex = dgvResults.CurrentRow.Index;
                lstInventory[lstIntCurrentIndex[intIndex]].intQuantity += lstShoppingCartQuantity[intIndex];
                LoadNext();
                dgvResults.Rows.RemoveAt(intIndex);
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
