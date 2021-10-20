using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{
    /* This class stores all variables associated with an account */
    public class Account
    {

        public Account()
        {

        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string User_Type { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DateOfBirth { get; set; }
        public string UsernameIn { get; set; }
        public string PasswordIn { get; set; }

    }
}
