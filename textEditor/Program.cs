using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AccountHandler accountLoad = new AccountHandler();

            if (accountLoad.accountD.ContainsKey("user1"))
            {
                Account account = accountLoad.accountD["RitMe"];
                MessageBox.Show(account.DateOfBirth);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }
    }
}
