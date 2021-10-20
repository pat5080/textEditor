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
    /* The class defines the about dialog box */
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Show();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
