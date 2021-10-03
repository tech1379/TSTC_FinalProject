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
    public partial class frmMain : Form
    {
        public static string strPersonID = frmLogIn.strPersonID;
        private int intSelectedImageID = 0;
        private int intCurrent = 0;
        public int intCouponCode = 0;
        public static decimal decSubTotal = 0;
        public static decimal decDiscountPercent;
        public static decimal decDiscount;
        public static decimal decSubTotalDiscount;
        public static decimal decTaxes = 0;
        public static decimal decTotal = 0;
        public static bool boolOrderMade = false;
        public static bool boolQuailOrderMade = false;
        public static string strPhoneNumber;
        public static decimal decQuailHuntTotal = 0;
        public string strMaxOrderID;
        public string strQuailHuntOrderID;
        public bool boolHasAccount = frmLogIn.boolHasAccount;
        List<clsInventory> lstInventory = new List<clsInventory>();
        List<clsCoupon> lstCoupon = new List<clsCoupon>();
        List<clsDayPrice> lstDayPrice = new List<clsDayPrice>();
        List<string> lstShoppingCartName = new List<string>();
        List<int> lstIntCurrentIndex = new List<int>();
        List<int> lstShoppingCartInventoryID = new List<int>();
        List<decimal> lstShoppingCartCost = new List<decimal>();
        List<int> lstShoppingCartQuantity = new List<int>();
        string strFirstName = "";
        string strLastName = "";
        public string strStartDateQuail = "";
        public string strEndDateQuail = "";
        public string message = "I'm sorry an error has occurred in the program. \n\n" +
            "Please inform the Program Developer that the following error occurred: \n\n\n";
        public frmMain()
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
                lstDayPrice = clsSQL.LoadPrice();
                DateTime now = DateTime.Now;
                for (int i = 0; i < lstCoupon.Count; i++)
                {
                    if (lstCoupon[i].dtExpirationDate >= now)
                    {
                        cbxCouponCode.Items.Add(lstCoupon[i].intCouponID);
                    }
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
                string strPhoneNumberQuery = "SELECT PhonePrimary FROM tekelle21fa2332.Person WHERE PersonID = " + Convert.ToInt32(strPersonID) + ";";
                strPhoneNumber = clsSQL.DatabaseCommandLogon(strPhoneNumberQuery);
                strFirstName = clsSQL.DatabaseCommandLogon(strQueryFirstName);
                strLastName = clsSQL.DatabaseCommandLogon(strQueryLastName);
                lblCustomer.Text = strFirstName + " " + strLastName;

                for (int i = 0; i < lstDayPrice.Count; i++)
                {
                    cbxDayPrice.Items.Add(lstDayPrice[i].decDayPrice.ToString("N2"));
                }



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
                    return;
                }
                if(lstInventory[intCurrent].intQuantity <= 0)
                {
                    MessageBox.Show("No items in stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                dgvResults.Rows.Add();
                //load DGV
                //fill the datagrid view with values from Shop form
                for (int i = 0; i < lstShoppingCartName.Count(); i++)
                {
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
                if (lstShoppingCartName.Count == 0)
                {
                    MessageBox.Show("Nothing to Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool boolCreditCardUpdate = CreditCardUpdate();
                if(boolCreditCardUpdate == false)
                {
                    MessageBox.Show("Credit Card Information Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                GetCouponCode();
                string strInsertOrder = "INSERT INTO tekelle21fa2332.Orders VALUES (" + Convert.ToInt32(strPersonID) +
                    ", '" + date + "', " + decTotal + ", " + intCouponCode + ");";
                clsSQL.UpdateDatabase(strInsertOrder);
                string strMaxOrderIDQuery = "SELECT MAX(OrderID) FROM tekelle21fa2332.Orders;";
                strMaxOrderID = clsSQL.DatabaseCommandLogon(strMaxOrderIDQuery);
                for (int i = 0; i < lstShoppingCartInventoryID.Count; i++)
                {
                    string strInsertOrderItems = "INSERT INTO tekelle21fa2332.OrderItems VALUES (" + lstShoppingCartInventoryID[i] + ", " + Convert.ToInt32(strMaxOrderID) +
                        ", " + lstShoppingCartQuantity[i] + ", " + lstShoppingCartCost[i] + ");";
                    clsSQL.UpdateDatabase(strInsertOrderItems);
                    string strInsertQuantity = "UPDATE tekelle21fa2332.Inventory SET Quantity = Quantity - " + lstShoppingCartQuantity[i] + " WHERE InventoryID = " + lstShoppingCartInventoryID[i] + ";";
                    clsSQL.UpdateDatabase(strInsertQuantity);
                }
                boolOrderMade = true;
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
        public bool CreditCardUpdate()
        {
            //validate credit card and expiration format and update database
            bool boolCreditCardUpdate = false;
            try
            {
                string strCreditCard = tbxCreditCard.Text;
                string strExpiration = tbxExpiration.Text;
                if (strCreditCard == "")
                {
                    MessageBox.Show("Credit Card cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolCreditCardUpdate = false;
                }
                else if (!clsValidation.ValidCreditCard(strCreditCard))
                {
                    MessageBox.Show("Credit Card Format 1234-5678-1234-5678.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolCreditCardUpdate = false;
                }
                else if (strExpiration == "")
                {
                    MessageBox.Show("Expiration Date cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolCreditCardUpdate = false;
                }
                else if (!clsValidation.ValidExpiration(strExpiration))
                {
                    MessageBox.Show("Expiration Date Format MM/YY.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolCreditCardUpdate = false;
                }
                else if (ExpirationDatePast(strExpiration))
                {
                    MessageBox.Show("Card is Expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolCreditCardUpdate = false;
                }
                else
                {
                    string strInsertCreditCardQuery = "INSERT INTO tekelle21fa2332.CreditCard VALUES (" + Convert.ToInt32(strPersonID) + ", '" + strCreditCard +
                        "', '" + strExpiration + "');";
                    clsSQL.UpdateDatabase(strInsertCreditCardQuery);
                    boolCreditCardUpdate = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return boolCreditCardUpdate;
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
                lstShoppingCartQuantity.RemoveAt(intIndex);
                lstShoppingCartName.RemoveAt(intIndex);
                lstShoppingCartCost.RemoveAt(intIndex);
                lstShoppingCartInventoryID.RemoveAt(intIndex);
                lstIntCurrentIndex.RemoveAt(intIndex);
                
            }
            catch(Exception ex)
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
                // CSS is a way to style the HTML page. Each HTML tag can be customized.
                // In this example, the H1 and TD tags are customized.
                // Refer to this website for examples: https://www.w3schools.com/Css/css_syntax.asp

                css.AppendLine("<style>");
                css.AppendLine("td {padding: 5px; text-align:center; font-weight: bold; text-align: center; font-size: 12px;}");
                css.AppendLine("h1 {color: orange;}");
                css.AppendLine("</style>");

                // HTML is used to format the layout of a webpage. This will be the frame
                // we use to place our data in. CSS is used to style the page to look a
                // certain way.

                // The <HTML> and </HTML> tags are the start and end of a webpage.
                // The <HEAD> and </HEAD> tags gives information about the webpage
                // such as the title and if there is any CSS styles being used.
                // The text between the <TITLE> and </TITLE> tags are used by the
                // browser to display the name of the page.
                // <BODY> and </BODY> is where the data of the page is stored
                // <H1> and </H1> is the largest font size for headings. These
                // can be from H1 to H6. H6 is the smallest font. https://www.w3schools.com/tags/tag_hn.asp

                html.AppendLine("<html>");
                css.AppendLine("<center {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</center>");
                html.AppendLine($"<head>{css}<title>{"Receipt"}</title></head>");
                //css.AppendLine("<left {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</left>");
                html.Append("<img src= logo.PNG style=' align: center; width: 75px; height: 50px;'>");
                html.AppendLine("<body>");

                html.AppendLine($"<h1>{" Order Receipt"}</h1>");
                html.Append($"<br></br>");
                html.Append($"<p style = 'text-indent: -550px; font-size: 15px'><b>{"Customer: " + strFirstName + " " + strLastName}</b></p>");
                html.Append($"<p style = 'text-indent: -550px; font-size: 15px'><b>{"Order Number: " + strMaxOrderID}</b></p>");
                html.Append($"<p style = 'text-indent: -550px; font-size: 10px'><b>{"Phone Number: " + strPhoneNumber}</b></p>");
                // Create table of data
                // <TABLE> and </TABLE> is the start and end of a table of rows and data.
                // <TR> and </TR> is one row of data. They contain <TD> and </TD> tags.
                // <TD> and </TD> represents the data inside of the table in a particular row.
                // https://www.w3schools.com/tags/tag_table.asp

                // I used an <HR /> tag which is a "horizontal rule" as table data.
                // You can "span" it across multiple columns of data.

                html.AppendLine("<table>");
                html.AppendLine("<tr><td>Item Name</td><td>Quantity</td><td>Price</td></tr>");
                html.AppendLine("<tr><td colspan=3><hr /></td></tr>");
                for (int i = 0; i < lstShoppingCartName.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{lstShoppingCartName[i]}</td>");
                    html.Append($"<td>{lstShoppingCartQuantity[i]}</td>");
                    html.Append($"<td>{lstShoppingCartCost[i]}</td>");
                    html.Append("</tr>");
                    html.AppendLine("<tr><td colspan=4><hr /></td></tr>");
                }
                html.AppendLine("</table>");
                html.Append($"<br></br><br></br>");
                html.Append($"<p style = 'align:center; text-indent: 390px; font-size: 10px '><b>{"SubTotal: " + decSubTotal.ToString("C2")}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 385px; font-size: 10px '><b>{"Discount Percent: " + decDiscountPercent.ToString("N3")}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 405px; font-size: 10px '><b>{"Discount: " + decDiscount.ToString("C2")}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 336px; font-size: 10px '><b>{"SubTotal After Discount: " + decSubTotalDiscount.ToString("C2")}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 420px; font-size: 10px '><b>{"Taxes: " + decTaxes.ToString("C2")}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 450px; font-size: 20px ' ><b>{"Total: " + decTotal.ToString("C2")}</b></p>");
                html.Append($"<div><button onClick='window.print()'> {"Print this page"}</ button ></ div >");
                html.AppendLine("</body></html>");
            }
            catch(Exception ex)
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
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
                using (StreamWriter writer = new StreamWriter("Report.html"))
                {
                    writer.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@"Report.html"); //Open the report in the default web browser
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!boolOrderMade)
                {
                    MessageBox.Show("You have to make an Order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                StringBuilder html = new StringBuilder();
                html = GenerateReport();
                PrintReport(html);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults.RowCount == 0)
                {
                    MessageBox.Show("Nothing to Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intIndex = dgvResults.CurrentRow.Index;
                for (int i = 0; i < lstShoppingCartName.Count; i++)
                {
                    lstInventory[lstIntCurrentIndex[i]].intQuantity += lstShoppingCartQuantity[i];
                }
                LoadNext();
                lstShoppingCartName.Clear();
                    lstShoppingCartCost.Clear();
                    lstShoppingCartQuantity.Clear();
                    lstShoppingCartInventoryID.Clear();
                    lstIntCurrentIndex.Clear();
                
                //clear the datagrid view
                dgvResults.Rows.Clear();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookHunt_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtStartDate = mthStart.SelectionRange.Start;
                DateTime dtEndDate = mthEnd.SelectionRange.Start;
                DateTime dtNow = DateTime.Now;
                int intResult = DateTime.Compare(dtStartDate, dtNow);
                int intResult2 = DateTime.Compare(dtEndDate, dtNow);
                if (intResult <= 0 || intResult2 <= 0)
                {
                    MessageBox.Show("You cannot book a hunt for today. Please select date in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int intTotalDays = (dtEndDate - dtStartDate).Days;
                if (cbxDayPrice.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a day price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decQuailHuntTotal = (intTotalDays * Convert.ToDecimal(cbxDayPrice.SelectedItem));
                lblQuailTotal.Text = decQuailHuntTotal.ToString("C2");
                strStartDateQuail = dtStartDate.ToString("yyyy-MM-dd");
                strEndDateQuail = dtEndDate.ToString("yyyy-MM-dd");
                int intDayPriceID = cbxDayPrice.SelectedIndex;
                string strInsertQuailHunt = "INSERT INTO tekelle21fa2332.QuailHuntOrders VALUES (" + strPersonID + ", '" + strStartDateQuail + "', '" + strEndDateQuail + "', " + decQuailHuntTotal + ", " + lstDayPrice[cbxDayPrice.SelectedIndex].intDayPriceID + ");";
                clsSQL.UpdateDatabase(strInsertQuailHunt);
                MessageBox.Show("Quail Hunt Successfully Booked", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string strQuailHuntOrderQuery = "SELECT MAX(QuailHuntID) FROM tekelle21fa2332.QuailHuntOrders;";
                strQuailHuntOrderID = clsSQL.DatabaseCommandLogon(strQuailHuntOrderQuery);
                boolQuailOrderMade = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private StringBuilder GenerateQuailHuntReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();
            try
            {
                // CSS is a way to style the HTML page. Each HTML tag can be customized.
                // In this example, the H1 and TD tags are customized.
                // Refer to this website for examples: https://www.w3schools.com/Css/css_syntax.asp

                css.AppendLine("<style>");
                css.AppendLine("td {padding: 5px; text-align:center; font-weight: bold; text-align: center; font-size: 12px;}");
                css.AppendLine("h1 {color: orange;}");
                css.AppendLine("</style>");

                html.AppendLine("<html>");
                css.AppendLine("<center {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</center>");
                html.AppendLine($"<head>{css}<title>{"Receipt"}</title></head>");
                //css.AppendLine("<left {display: block;margin - left: auto;margin - right: auto;width: 50 %;}</left>");
                html.Append("<img src= logo.PNG style=' align: center; width: 75px; height: 50px;'>");
                html.AppendLine("<body>");

                html.AppendLine($"<h1>{" Order Receipt"}</h1>");
                html.Append($"<br></br>");
                html.Append($"<p style = 'text-indent: -550px; font-size: 25px'><b>{"Customer: " + strFirstName + " " + strLastName}</b></p>");
                html.Append($"<p style = 'text-indent: -550px; font-size: 25px'><b>{"Order Number: " + strQuailHuntOrderID}</b></p>");
                html.Append($"<p style = 'text-indent: -550px; font-size: 20px'><b>{"Phone Number: " + strPhoneNumber}</b></p>");
                
                html.Append($"<br></br><br></br>");
                html.Append($"<p style = 'align:center; text-indent: 390px; font-size: 25px '><b>{"Start Date: " + strStartDateQuail}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 385px; font-size: 25px '><b>{"End Date: " + strEndDateQuail}</b></p>");
                html.Append($"<p style = 'align:center; text-indent: 405px; font-size: 25px '><b>{"Total: " + decQuailHuntTotal.ToString("C2")}</b></p>");
                html.Append($"<div><button onClick='window.print()'> {"Print this page"}</ button ></ div >");
                html.AppendLine("</body></html>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return html; // The returned value has all the HTML and CSS code to represent a webpage
        }
        private void PrintQuailReport(StringBuilder html)
        {
            // Write (and overwrite) to the hard drive using the same filename of "Report.html"
            try
            {
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
                using (StreamWriter writer = new StreamWriter("QuailReport.html"))
                {
                    writer.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@"QuailReport.html"); //Open the report in the default web browser
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuailReciept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!boolQuailOrderMade)
                {
                    MessageBox.Show("You have to book a Quail Hunt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                StringBuilder html = new StringBuilder();
                html = GenerateQuailHuntReport();
                PrintQuailReport(html);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
