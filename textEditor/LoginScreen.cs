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
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Account account = new Account(textBox1.Text, textBox2.Text);
        }

        private void Newuser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New user button was clicked.");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exit button was clicked.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
