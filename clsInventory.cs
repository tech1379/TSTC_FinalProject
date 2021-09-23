using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA21_Final_Project
{
    public class clsInventory
    {
        //class to store inventory data from db
        public int intInventoryID { get; set; }
        public string strItemName { get; set; }
        public string strItemDescription { get; set; }
        public decimal decRetailPrice { get; set; }
        public decimal decCost { get; set; }
        public int intQuantity { get; set; }
        public byte[] bytImage { get; set; }
        public bool boolDiscontinued { get; set; }
       

       public clsInventory()
        {

        }

    }
}
