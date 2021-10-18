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
        public NewUserScreen(AccountHandler accountLoad)
        {
            InitializeComponent();
            Show();
            this.accountLoad = accountLoad;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen login1 = new LoginScreen(accountLoad);

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (fieldCheck(textBox1.Text) && fieldCheck(textBox2.Text) && fieldCheck(textBox3.Text) 
                && fieldCheck(textBox4.Text) && fieldCheck(textBox5.Text) && 
                fieldCheck(comboBox1.SelectedIndex.ToString()) && fieldCheck(dateTimePicker1.Value.ToString()))
            {
                MessageBox.Show("New user entered.");
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
