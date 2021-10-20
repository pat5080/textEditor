using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace textEditor
{
    /* This class stores all accounts into a dictionary data structure that is passed around between screens to access/add accounts */
    public class AccountHandler
    {
        private Dictionary<string, Account> AccountD = new Dictionary<string, Account>();

        public AccountHandler()
        {
            
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

            AccountD.Add(account.Username, account);
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

            return indices;
        }

        private void SaveAccounts()
        {
            string[] lines = new string[AccountD.Count];
            int count = 0;

            // Store an array of strings
            foreach(KeyValuePair<string,Account> keyValue in AccountD)
            {
                string username = keyValue.Key;
                Account account = keyValue.Value;

                lines[count] = username + "," + account.Password + "," + account.User_Type + 
                    "," + account.First_Name + "," + account.Last_Name + "," + account.DateOfBirth;

                count++;
            }

            try
            {
                File.WriteAllLines("login.txt", lines);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + "writing to login.txt failed");
            }
        }

        public bool AddAccount(Account account)
        {
            if (AccountD.ContainsKey(account.Username))
            {
                return false;
            }
            else
            {
                AccountD.Add(account.Username, account);

                SaveAccounts();

                return true;
            }
        }

        public string printDictionary()
        {
            string a = AccountD.ToString();
            return a;
        }

        public bool checkAccount(string username, string password)
        {
            if (AccountD.ContainsKey(username))
            {
                Account account = AccountD[username];

                if(password == account.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public string getUserType(string username)
        {
            Account account = AccountD[username];

            return account.User_Type;
        }
    }
}
