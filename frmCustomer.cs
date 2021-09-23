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
        private int intSelectedImageID = 0;
        private int intCurrent = 0;
        public bool boolHasAccount = frmMain.boolHasAccount;
        List<clsInventory> lstInventory = new List<clsInventory>();
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
                lstInventory.Clear();
                lstInventory = clsSQL.ReloadImageList();

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
                    this.tbCustomer.TabPages.Remove(tbQuailHunts);
                    this.tbCustomer.TabPages.Remove(tbTraining);
                    this.tbCustomer.TabPages.Remove(tbShoppingCart);
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

        
    }
}
