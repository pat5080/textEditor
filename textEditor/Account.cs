using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{
    class Account
    {
        public Account(string username, string password)
        {
            UsernameIn = username;
            PasswordIn = password;

            //MessageBox.Show(UsernameIn + " " + PasswordIn);
        }

        public Account()
        {

        }

        //Dictionary<int, string> account = new Dictionary<int, string>();

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
