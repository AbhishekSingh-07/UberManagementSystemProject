using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard
{
    class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }


        public override string ToString()
        {
            string admindata = "";
            admindata += AdminId.ToString() + "\n";
            admindata += UserName.ToString() + "\n";
            admindata += FullName.ToString() + "\n";
            admindata += Email.ToString() + "\n";
            admindata += ContactNumber.ToString() + "\n";
            admindata += Password.ToString() + "\n";


            return admindata;
        }
    }
}
