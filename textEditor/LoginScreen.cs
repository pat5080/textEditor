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
    public partial class LoginScreen : Form
    {
        AccountHandler accountLoad;

        public LoginScreen(ref AccountHandler accountLoad)
        {
            InitializeComponent();
            this.accountLoad = accountLoad;
            Show();
        }

        

        private void Login_Click(object sender, EventArgs e)
        {
            if(accountLoad.checkAccount(textBox1.Text, textBox2.Text))
            {
                //MessageBox.Show("Login credentials are valid.");
                TextEditorWindow newEdit = new TextEditorWindow(ref accountLoad);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login credentials are invalid. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Account account = new Account(textBox1.Text, textBox2.Text);
        }

        private void Newuser_Click(object sender, EventArgs e)
        {
            NewUserScreen newUser = new NewUserScreen(ref accountLoad);
            this.Hide();
            //newUser.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
