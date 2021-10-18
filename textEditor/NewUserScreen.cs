using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditor
{
    public partial class NewUserScreen : Form
    {
        AccountHandler accountLoad;
        public NewUserScreen(ref AccountHandler accountLoad)
        {
            InitializeComponent();
            Show();
            this.accountLoad = accountLoad;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen login1 = new LoginScreen(ref accountLoad);

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if ((fieldCheck(textBox1.Text) && fieldCheck(textBox2.Text) && fieldCheck(textBox3.Text) 
                && fieldCheck(textBox4.Text) && fieldCheck(textBox5.Text) && 
                comboBox1.SelectedItem != null && fieldCheck(dateTimePicker1.Value.Date.ToString("dd-MM-yyyy"))) &&
                (textBox2.Text == textBox3.Text))
            {
                Account newAccount = new Account();

                newAccount.Username = textBox1.Text;
                newAccount.Password = textBox2.Text;
                newAccount.User_Type = comboBox1.SelectedItem.ToString();
                newAccount.First_Name = textBox4.Text;
                newAccount.Last_Name = textBox5.Text;
                newAccount.DateOfBirth = dateTimePicker1.Value.Date.ToString("dd-MM-yyyy");

                /*
                MessageBox.Show(newAccount.Username+","+newAccount.Password+","+newAccount.User_Type+","+newAccount.First_Name
                    +","+newAccount.Last_Name+","+newAccount.DateOfBirth.ToString());
                */
                bool flag = accountLoad.AddAccount(newAccount);

                if(!flag)
                {
                    MessageBox.Show("Please type a unique username. The current username is already taken.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Hide();
                    LoginScreen login1 = new LoginScreen(ref accountLoad);
                }
            }
            else if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("The passwords do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Do not leave any fields blank!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool fieldCheck(string text)
        {
            if(text.Length > 0)
            {
                return true;
            }

            return false;
        }

    }
}
