using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC_PACKAGING.src.model
{
    public class Product
    {
        public int ProductID { get; set; }
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Printing { get; set; }
        public string Printing_block { get; set; }
        public string Category { get; set; }
        public double Unit_price { get; set; }
    }
}
