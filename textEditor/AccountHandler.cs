using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace textEditor
{
    class AccountHandler
    {
        //Queue<Account> accountList = new Queue<Account>();

        public Dictionary<string, Account> accountD = new Dictionary<string, Account>();

        public AccountHandler()
        {
            LoadAccounts();
        }

        public void LoadAccounts()
        {
            try
            {
                 var login = File.ReadLines("login.txt");

                foreach(var line in login)
                {
                    storeAccount(line);
                }

            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + "login.txt not found");
            }
        }

        private void storeAccount(string line)
        {
            List<int> commas = delimiterLocations(line);

            string username;
            string password;
            string user_type;
            string first_name;
            string last_name;
            string dateOfbirth;

            username = line.Substring(0, commas[0]);
            password = line.Substring(commas[0]+1, commas[1]-commas[0]-1);
            user_type = line.Substring(commas[1] + 1, commas[2]-commas[1]-1);
            first_name = line.Substring(commas[2] + 1, commas[3]-commas[2]-1);
            last_name = line.Substring(commas[3] + 1, commas[4]-commas[3]-1);
            dateOfbirth = line.Substring(commas[4] + 1);

            Account account = new Account();

            account.Username = username;
            account.Password = password;
            account.User_Type = user_type;
            account.First_Name = first_name;
            account.Last_Name = last_name;
            account.DateOfBirth = dateOfbirth;

            accountD.Add(account.Username, account);
        }

        private List<int> delimiterLocations(string line)
        {
            List<int> indices = new List<int>();

            for (int i = 0; i < line.Length; i++)
            {
                if(line[i] == ',')
                {
                    indices.Add(i);
                }
            }
            /*
            for (int i = line.IndexOf(','); i > -1; i = line.IndexOf(',', i + 1))
            {
                indices.Add(i);
            } */

            return indices;
        }

        public void SaveAccounts()
        {

        }

        public string printDictionary()
        {
            string a = accountD.ToString();
            return a;
        }

    }
}
