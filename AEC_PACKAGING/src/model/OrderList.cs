using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC_PACKAGING.src.model
{
    public class OrderList
    {
        public int ListID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public double Design_fee { get; set; }
        public string Remarks { get; set; }

        public double Unit_price { get; set; }
    }
}
