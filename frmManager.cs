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

namespace FA21_Final_Project
{
    public partial class frmManager : Form
    {
        int intMouseCount = 0;
        int intMouseCount1 = 0;
        public static int intInventoryID = 0;
        List<clsInventory> lstInventory = new List<clsInventory>();
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
                string strSqlInventoryQuery = "SELECT InventoryID, ItemName, ItemDescription, RetailPrice, Cost, Quantity, Discontinued FROM tekelle21fa2332.Inventory;";
                clsSQL.DatabaseCommand(strSqlInventoryQuery, dgvResults);
            }
            catch (Exception ex)
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
                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete an item?", "Inventory Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    int intIndex = dgvResults.CurrentRow.Index;
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
    }
}
