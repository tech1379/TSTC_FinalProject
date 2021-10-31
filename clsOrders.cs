using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA21_Final_Project
{
    class clsOrders
    {
        public int intOrderID { get; set; }

        public int intPersonID { get; set; }

        public DateTime dtOrderDate { get; set; }

        public decimal decOrderTotal { get; set; }

        public int intCouponID { get; set; }
    }
}
