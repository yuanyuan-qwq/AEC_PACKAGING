using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC_PACKAGING.src.model
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string IC { get; set; }
        public string Name { get; set; }
        public string Phone_num { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Salary { get; set; }
        public int? Referral_StaffID { get; set; }
    }
}
