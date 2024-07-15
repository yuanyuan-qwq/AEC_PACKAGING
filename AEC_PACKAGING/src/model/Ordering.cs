using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC_PACKAGING.src.model
{
    public class Ordering
    {
        public int OrderID { get; set; }
        public int StaffID { get; set; }
        public int ClientID { get; set; }
        public DateTime Order_date { get; set; }
        public double Transportation_cost { get; set; }

        public string Status { get; set; }
    }
}
