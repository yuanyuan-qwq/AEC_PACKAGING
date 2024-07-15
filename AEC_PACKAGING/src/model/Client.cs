using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC_PACKAGING.src.model
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Company_name { get; set; }
        public string Company_address { get; set; }
        public string Company_num { get; set; }
        public string Fax_num { get; set; }
        public string PIC_name { get; set; }
        public string PIC_num { get; set; }
        public string PIC_email { get; set; }
        public int? StaffID { get; set; }
    }
}
