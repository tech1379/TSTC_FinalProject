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
        public static decimal decSubTotal = 0;
        public static decimal decTaxes = 0;
        public static decimal decTotal = 0;
        public bool boolHasAccount = frmMain.boolHasAccount;
        List<clsInventory> lstInventory = new List<clsInventory>();
        List<clsCoupon> lstCoupon = new List<clsCoupon>();
        List<string> lstShoppingCartName = new List<string>();
        List<decimal> lstShoppingCartPrice = new List<decimal>();
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
                lstShoppingCartPrice.Add(lstInventory[intCurrent].decRetailPrice);
                lstShoppingCartQuantity.Add(Convert.ToInt32(cbxQuantity.SelectedItem));
                lstInventory[intCurrent].intQuantity -= Convert.ToInt32(cbxQuantity.SelectedItem);
                lblQuantity.Text = lstInventory[intCurrent].intQuantity.ToString();
                LoadDGV();
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDGV()
        {
            //load DGV
            //fill the datagrid view with values from Shop form
            for (int i = 0; i < lstShoppingCartName.Count(); i++)
            {
                dgvResults.Rows.Add();
                dgvResults[0, i].Value = lstShoppingCartName[i];
                dgvResults[1, i].Value = lstShoppingCartQuantity[i];
                dgvResults[2, i].Value = (lstShoppingCartQuantity[i] * lstShoppingCartPrice[i]);
                decSubTotal += Convert.ToDecimal(dgvResults[2, i].Value);
            }
            lblSubTotal.Text = decSubTotal.ToString();
            decTaxes = (decSubTotal * (decimal)(.0825));
            lblTaxes.Text = decTaxes.ToString("N2");
            decTotal = decSubTotal + decTaxes;
            lblTotal.Text = decTotal.ToString("N2");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnCart_Click(object sender, EventArgs e)
        {
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

       
    }
}
